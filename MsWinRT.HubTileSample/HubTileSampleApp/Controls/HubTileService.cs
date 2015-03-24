using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace HubTileSampleApp.Controls
{
    public static class HubTileService
    {
        private static DispatcherTimer Timer = new DispatcherTimer();
        private static Random ProbabilisticBehaviorSelector = new Random();
        private static List<WeakReference> EnabledImagesPool = new List<WeakReference>();
        private static List<WeakReference> FrozenImagesPool = new List<WeakReference>();
        private static List<WeakReference> StalledImagesPipeline = new List<WeakReference>();
        private const int WaitingPipelineSteps = 3;
        private const int NumberOfSimultaneousAnimations = 1;
        private const bool TrackResurrection = false;

        static HubTileService()
        {
            HubTileService.Timer.Tick += HubTileService.OnTimerTick;
        }

        private static void RestartTimer()
        {
            if (HubTileService.Timer.IsEnabled)
                return;
            HubTileService.Timer.Interval = TimeSpan.FromMilliseconds(2500.0);
            HubTileService.Timer.Start();
        }

        internal static void InitializeReference(HubTile tile)
        {
            WeakReference tile1 = new WeakReference((object)tile, false);
            if (tile.IsFrozen)
                HubTileService.AddReferenceToFrozenPool(tile1);
            else
                HubTileService.AddReferenceToEnabledPool(tile1);
            HubTileService.RestartTimer();
        }

        internal static void FinalizeReference(HubTile tile)
        {
            WeakReference tile1 = new WeakReference((object)tile, false);
            HubTileService.RemoveReferenceFromEnabledPool(tile1);
            HubTileService.RemoveReferenceFromFrozenPool(tile1);
            HubTileService.RemoveReferenceFromStalledPipeline(tile1);
        }

        private static void AddReferenceToEnabledPool(WeakReference tile)
        {
            if (HubTileService.ContainsTarget(HubTileService.EnabledImagesPool, tile.Target))
                return;
            HubTileService.EnabledImagesPool.Add(tile);
        }

        private static void AddReferenceToFrozenPool(WeakReference tile)
        {
            if (HubTileService.ContainsTarget(HubTileService.FrozenImagesPool, tile.Target))
                return;
            HubTileService.FrozenImagesPool.Add(tile);
        }

        private static void AddReferenceToStalledPipeline(WeakReference tile)
        {
            if (HubTileService.ContainsTarget(HubTileService.StalledImagesPipeline, tile.Target))
                return;
            HubTileService.StalledImagesPipeline.Add(tile);
        }

        private static void RemoveReferenceFromEnabledPool(WeakReference tile)
        {
            HubTileService.RemoveTarget(HubTileService.EnabledImagesPool, tile.Target);
        }

        private static void RemoveReferenceFromFrozenPool(WeakReference tile)
        {
            HubTileService.RemoveTarget(HubTileService.FrozenImagesPool, tile.Target);
        }

        private static void RemoveReferenceFromStalledPipeline(WeakReference tile)
        {
            HubTileService.RemoveTarget(HubTileService.StalledImagesPipeline, tile.Target);
        }

        private static bool ContainsTarget(List<WeakReference> list, object target)
        {
            for (int index = 0; index < list.Count; ++index)
            {
                if (list[index].Target == target)
                    return true;
            }
            return false;
        }

        private static void RemoveTarget(List<WeakReference> list, object target)
        {
            for (int index = 0; index < list.Count; ++index)
            {
                if (list[index].Target == target)
                {
                    list.RemoveAt(index);
                    break;
                }
            }
        }

        private static void OnTimerTick(object sender, object e)
        {
            HubTileService.Timer.Stop();
            for (int index = 0; index < HubTileService.StalledImagesPipeline.Count; ++index)
            {
                if ((HubTileService.StalledImagesPipeline[index].Target as HubTile)._stallingCounter-- == 0)
                {
                    HubTileService.AddReferenceToEnabledPool(HubTileService.StalledImagesPipeline[index]);
                    HubTileService.RemoveReferenceFromStalledPipeline(HubTileService.StalledImagesPipeline[index]);
                    --index;
                }
            }
            if (HubTileService.EnabledImagesPool.Count > 0)
            {
                for (int index1 = 0; index1 < 1; ++index1)
                {
                    int index2 = HubTileService.ProbabilisticBehaviorSelector.Next(HubTileService.EnabledImagesPool.Count);
                    switch ((HubTileService.EnabledImagesPool[index2].Target as HubTile).State)
                    {
                        case ImageState.Expanded:
                            if ((HubTileService.EnabledImagesPool[index2].Target as HubTile)._canDrop || (HubTileService.EnabledImagesPool[index2].Target as HubTile)._canFlip)
                            {
                                if (!(HubTileService.EnabledImagesPool[index2].Target as HubTile)._canDrop && (HubTileService.EnabledImagesPool[index2].Target as HubTile)._canFlip)
                                {
                                    (HubTileService.EnabledImagesPool[index2].Target as HubTile).State = ImageState.Flipped;
                                    break;
                                }
                                else if (!(HubTileService.EnabledImagesPool[index2].Target as HubTile)._canFlip && (HubTileService.EnabledImagesPool[index2].Target as HubTile)._canDrop)
                                {
                                    (HubTileService.EnabledImagesPool[index2].Target as HubTile).State = ImageState.Semiexpanded;
                                    break;
                                }
                                else if (HubTileService.ProbabilisticBehaviorSelector.Next(2) == 0)
                                {
                                    (HubTileService.EnabledImagesPool[index2].Target as HubTile).State = ImageState.Semiexpanded;
                                    break;
                                }
                                else
                                {
                                    (HubTileService.EnabledImagesPool[index2].Target as HubTile).State = ImageState.Flipped;
                                    break;
                                }
                            }
                            else
                                break;
                        case ImageState.Semiexpanded:
                            (HubTileService.EnabledImagesPool[index2].Target as HubTile).State = ImageState.Collapsed;
                            break;
                        case ImageState.Collapsed:
                            (HubTileService.EnabledImagesPool[index2].Target as HubTile).State = ImageState.Expanded;
                            break;
                        case ImageState.Flipped:
                            (HubTileService.EnabledImagesPool[index2].Target as HubTile).State = ImageState.Expanded;
                            break;
                    }
                    (HubTileService.EnabledImagesPool[index2].Target as HubTile)._stallingCounter = 3;
                    HubTileService.AddReferenceToStalledPipeline(HubTileService.EnabledImagesPool[index2]);
                    HubTileService.RemoveReferenceFromEnabledPool(HubTileService.EnabledImagesPool[index2]);
                }
            }
            else if (HubTileService.StalledImagesPipeline.Count == 0)
                return;
            HubTileService.Timer.Interval = TimeSpan.FromMilliseconds((double)(HubTileService.ProbabilisticBehaviorSelector.Next(1, 31) * 100));
            HubTileService.Timer.Start();
        }

        public static void FreezeHubTile(HubTile tile)
        {
            WeakReference tile1 = new WeakReference((object)tile, false);
            HubTileService.AddReferenceToFrozenPool(tile1);
            HubTileService.RemoveReferenceFromEnabledPool(tile1);
            HubTileService.RemoveReferenceFromStalledPipeline(tile1);
        }

        public static void UnfreezeHubTile(HubTile tile)
        {
            WeakReference tile1 = new WeakReference((object)tile, false);
            HubTileService.AddReferenceToEnabledPool(tile1);
            HubTileService.RemoveReferenceFromFrozenPool(tile1);
            HubTileService.RemoveReferenceFromStalledPipeline(tile1);
            HubTileService.RestartTimer();
        }

        public static void FreezeGroup(string group)
        {
            for (int index = 0; index < HubTileService.EnabledImagesPool.Count; ++index)
            {
                if ((HubTileService.EnabledImagesPool[index].Target as HubTile).GroupTag == group)
                {
                    (HubTileService.EnabledImagesPool[index].Target as HubTile).IsFrozen = true;
                    --index;
                }
            }
            for (int index = 0; index < HubTileService.StalledImagesPipeline.Count; ++index)
            {
                if ((HubTileService.StalledImagesPipeline[index].Target as HubTile).GroupTag == group)
                {
                    (HubTileService.StalledImagesPipeline[index].Target as HubTile).IsFrozen = true;
                    --index;
                }
            }
        }

        public static void UnfreezeGroup(string group)
        {
            for (int index = 0; index < HubTileService.FrozenImagesPool.Count; ++index)
            {
                if ((HubTileService.FrozenImagesPool[index].Target as HubTile).GroupTag == group)
                {
                    (HubTileService.FrozenImagesPool[index].Target as HubTile).IsFrozen = false;
                    --index;
                }
            }
            HubTileService.RestartTimer();
        }
    }
}
