using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiLeo.Services.CouponAPI.Data;
using RiLeo.Services.CouponAPI.Models;
using RiLeo.Services.CouponAPI.Models.Dto;

namespace RiLeo.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public CouponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get() // ResponseDto is Custom ActionResult
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);


            }
            catch (Exception ex) 
            {
                _response.IsSucess = false;
                _response.Message = ex.Message + " " + ex.InnerException;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public object Get(int id)
        {
            try
            {
                var obj = _db.Coupons.First(x => x.CouponId == id);
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.Message = ex.Message + " " + ex.InnerException;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                var obj = _db.Coupons.First(x => x.CouponCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.Message = ex.Message + " " + ex.InnerException;
            }
            return _response;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            try
            {
                var obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Add(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.Message = ex.Message + " " + ex.InnerException;
            }
            return _response;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try
            {
                var obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.Message = ex.Message + " " + ex.InnerException;
            }
            return _response;
        }

        [HttpDelete]
        public ResponseDto Delete(int id)
        {
            try
            {
                var obj = _db.Coupons.First(x => x.CouponId == id);
                _db.Coupons.Remove(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.Message = ex.Message + " " + ex.InnerException;
            }
            return _response;
        }
    }
}
