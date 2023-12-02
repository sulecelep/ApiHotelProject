﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            _bookingService.TInsert(booking);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            if (value != null)
            {
                _bookingService.TDelete(value);
                return Ok();

            }
            return BadRequest();
        }
        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            return Ok(value);
        }
        //[HttpPut("UpdateReservationStatus")]
        //public IActionResult UpdateReservationStatus(Booking booking)
        //{
        //    _bookingService.TBookingStatusChangeApproved(booking);
        //    return Ok();
        //}
        //[HttpPut("UpdateReservationStatusApproved")]
        //public IActionResult UpdateReservationStatusApproved(int id)
        //{
        //    _bookingService.TBookingStatusChangeApproved2(id);
        //    return Ok();
        //}
        [HttpGet("Last6Booking")]
        public IActionResult Last6Booking()
        {
            var value = _bookingService.TLast6Bookings();
            return Ok(value);
        }
        [HttpGet("BookingApproved/{id}")]
        public IActionResult BookingApproved(int id)
        {
            _bookingService.TBookingStatusChangeApproved3(id);
            return Ok();
        }
        [HttpGet("BookingCancelled/{id}")]
        public IActionResult BookingCancelled(int id)
        {
            _bookingService.TBookingStatusChangeCancelled(id);
            return Ok();
        }
        [HttpGet("BookingWait/{id}")]
        public IActionResult BookingWait(int id)
        {
            _bookingService.TBookingStatusChangeWait(id);
            return Ok();
        }
    }
}
