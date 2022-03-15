using Carousal.BOs;
using Carousal.Helpers;
using System.Collections.ObjectModel;

namespace Carousal.Services.CarousalServices
{
    public interface ICarousalServices
    {
        public ServiceResult<ObservableCollection<CarousalBO>> GetAllCarousalData();
        public ServiceResult<int> AddCarousal(CarousalBO carousal);
        public ServiceResult<int> DeleteCarousal(int Id);
        public ServiceResult<int> UpdateCarousal (CarousalBO carousal);
        public ServiceResult<ObservableCollection<CarousalBO>> FetchOneCarousalData(int Id);
    }
}
