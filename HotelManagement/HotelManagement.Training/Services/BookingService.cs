using AutoMapper;
using HotelManagement.Common.Utilities;
using HotelManagement.Training.BusinessObjects;
using HotelManagement.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Training.Services
{
    public class BookingService : IBookingService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IDateTimeUtility _dateTimeUtility;
        private readonly IMapper _mapper;
        public BookingService(ITrainingUnitOfWork trainingUnitOfWork,
            IDateTimeUtility dateTimeUtility,
            IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _dateTimeUtility = dateTimeUtility;
            _mapper = mapper;

        }

        public void AddBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public void DeleteBooking(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Booking> GetAllBookings()
        {
            throw new NotImplementedException();
        }

        public Booking GetBooking(int id)
        {
            throw new NotImplementedException();
        }

        public (IList<Booking> records, int total, int totalDisplay) GetBookings(int pageIndex, int pageSize, string searchText, string sortText)
        {
            throw new NotImplementedException();
        }

        public void UpdateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
