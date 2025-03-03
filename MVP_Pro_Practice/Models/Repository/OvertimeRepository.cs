using MVP_Pro_Practice.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Pro_Practice.Models.Repository
{
    internal class OvertimeRepository
    {
        public List<OverTime> GetOverTimeByID(int ID)
        {
            switch (ID)
            {
                case 1:
                    return new List<OverTime>
            {
                new OverTime(1, 1, 2.5, new DateTime(2024, 12, 10), "專案緊急需求"),
                new OverTime(1, 1, 3.0, new DateTime(2024, 12, 11), "專案設計修改"),
                new OverTime(1, 1, 1.5, new DateTime(2024, 12, 12), "需求確認會議")
            };
                case 2:
                    return new List<OverTime>
            {
                new OverTime(2, 2, 3.0, new DateTime(2024, 12, 11), "產品發佈準備"),
                new OverTime(2, 2, 2.0, new DateTime(2024, 12, 12), "內部測試"),
                new OverTime(2, 2, 4.0, new DateTime(2024, 12, 13), "外部合作會議")
            };
                case 3:
                    return new List<OverTime>
            {
                new OverTime(3, 3, 1.5, new DateTime(2024, 12, 12), "系統維護"),
                new OverTime(3, 3, 2.0, new DateTime(2024, 12, 13), "系統部署"),
                new OverTime(3, 3, 3.5, new DateTime(2024, 12, 14), "服務監控問題處理")
            };
                case 4:
                    return new List<OverTime>
            {
                new OverTime(4, 4, 4.0, new DateTime(2024, 12, 13), "客戶回報問題處理"),
                new OverTime(4, 4, 2.5, new DateTime(2024, 12, 14), "客戶需求對接"),
                new OverTime(4, 4, 3.0, new DateTime(2024, 12, 15), "客戶回饋總結")
            };
                case 5:
                    return new List<OverTime>
            {
                new OverTime(5, 5, 2.0, new DateTime(2024, 12, 14), "文件更新"),
                new OverTime(5, 5, 1.5, new DateTime(2024, 12, 15), "內部培訓準備"),
                new OverTime(5, 5, 2.5, new DateTime(2024, 12, 16), "新文件審核")
            };
                case 6:
                    return new List<OverTime>
            {
                new OverTime(6, 6, 3.5, new DateTime(2024, 12, 15), "測試案例補充"),
                new OverTime(6, 6, 4.0, new DateTime(2024, 12, 16), "回歸測試"),
                new OverTime(6, 6, 2.0, new DateTime(2024, 12, 17), "測試報告撰寫")
            };
                default:
                    return new List<OverTime>();
            }
        }
    }
}
