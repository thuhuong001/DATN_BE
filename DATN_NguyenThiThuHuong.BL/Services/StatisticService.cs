using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_NguyenThiThuHuong.BL.Services
{
    public class StatisticService : IStatisticService
    {
        private IStatisticDL _statisticDL;
        public StatisticService(IStatisticDL statisticDL)
        {
            _statisticDL = statisticDL;
        }
        public object StatisticsDefault()
        {
            return _statisticDL.StatisticsDefault();
        }
    }
}
