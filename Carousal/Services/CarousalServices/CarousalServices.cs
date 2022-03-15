using Carousal.BOs;
using Carousal.Helpers;
using Carousal.Helpers.DataStore;
using System.Collections.ObjectModel;

namespace Carousal.Services.CarousalServices
{
    public class CarousalServices : ICarousalServices
    {
        public ServiceResult<int> AddCarousal(CarousalBO carousal)
        {
            try
            {
                var response = CarousalSchema.AddCarousalData(carousal.Id,carousal.Image, carousal.Description);
                if (response != null)
                {
                    return new ServiceResult<int>()
                    {
                        Status = ServiceStatus.Success,
                        Message = "Success",
                        Content = response
                    };
                }
                return new ServiceResult<int>()
                {
                    Status = ServiceStatus.Failed,
                    Message = "response from DB is null",
                    Content = 0

                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<int>()
                {
                    Status = ServiceStatus.Failed,
                    Message = ex.Message,
                    Content = 0
                };
            }
        }
        public ServiceResult<ObservableCollection<CarousalBO>> GetAllCarousalData()
        {
            try
            {
                var response = CarousalSchema.FetchAllCarousalData();
                if (response != null)
                {
                    return new ServiceResult<ObservableCollection<CarousalBO>>()
                    {
                        Status = ServiceStatus.Success,
                        Message = "Success",
                        Content = response
                    };
                }

                return new ServiceResult<ObservableCollection<CarousalBO>>()
                {
                    Status = ServiceStatus.Failed,
                    Message = "response from DB is null",
                    Content = null

                };

            }
            catch (Exception ex)
            {
                return new ServiceResult<ObservableCollection<CarousalBO>>()
                {
                    Status = ServiceStatus.Failed,
                    Message = ex.Message,
                    Content = null
                };
            }
        }
        public ServiceResult<int> DeleteCarousal(int Id)
        {
            try
            {
                var response = CarousalSchema.DeleteCarousalData(Id);
                if (response != null)
                {
                    return new ServiceResult<int>()
                    {
                        Status = ServiceStatus.Success,
                        Message = "Success",
                        Content = response
                    };
                }
                return new ServiceResult<int>()
                {
                    Status = ServiceStatus.Failed,
                    Message = "response from DB is null",
                    Content = 0

                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<int>()
                {
                    Status = ServiceStatus.Failed,
                    Message = ex.Message,
                    Content = 0
                };
            }
        }
        public ServiceResult<int> UpdateCarousal(CarousalBO carousal)
        {
            try
            {
                var response = CarousalSchema.UpdateCarousalData(carousal.Id, carousal.Image, carousal.Description);
                if (response != null)
                {
                    return new ServiceResult<int>()
                    {
                        Status = ServiceStatus.Success,
                        Message = "Success",
                        Content = response
                    };
                }
                return new ServiceResult<int>()
                {
                    Status = ServiceStatus.Failed,
                    Message = "response from DB is null",
                    Content = 0

                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<int>()
                {
                    Status = ServiceStatus.Failed,
                    Message = ex.Message,
                    Content = 0
                };
            }
        }
        public ServiceResult<ObservableCollection<CarousalBO>> FetchOneCarousalData(int Id)
        {
            try
            {
                var response = CarousalSchema.FetchOneCarousalContent(Id);
                if (response != null)
                {
                    return new ServiceResult<ObservableCollection<CarousalBO>>()
                    {
                        Status = ServiceStatus.Success,
                        Message = "Success",
                        Content = response
                    };
                }

                return new ServiceResult<ObservableCollection<CarousalBO>>()
                {
                    Status = ServiceStatus.Failed,
                    Message = "response from DB is null",
                    Content = null

                };

            }
            catch (Exception ex)
            {
                return new ServiceResult<ObservableCollection<CarousalBO>>()
                {
                    Status = ServiceStatus.Failed,
                    Message = ex.Message,
                    Content = null
                };
            }
        }
    }
}
