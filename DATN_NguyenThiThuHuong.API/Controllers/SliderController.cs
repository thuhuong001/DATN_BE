using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.Common.Models;

namespace DATN_NguyenThiThuHuong.API.Controllers
{
    public class SliderController : BaseController<Slider>
    {
        private IBaseService<Slider> _baseSerive;
        public SliderController(IBaseService<Slider> baseSerive, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(baseSerive, httpContextAccessor, userTokenService)
        {
            _baseSerive = baseSerive;
        }

    }
}
