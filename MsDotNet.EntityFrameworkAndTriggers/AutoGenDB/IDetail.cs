using System;
namespace AutoGenDB
{
    interface IDetail
    {
        int? AutoGenNumber { get; set; }
        string AutoGenPrefix { get; set; }
        int Id { get; set; }
        Master Master { get; set; }
        int MasterId { get; set; }
    }
}
