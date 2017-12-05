using PlaneBooking.DAL.Repo.Base;
using PlaneBooking.Models.Entities.Base;
using PlaneBooking.Models.Response;
using PlaneBooking.Models.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneBooking.WebService.Services.Base
{
    public interface ICrudServiceBase<TEntity, TView, TRepo>
		where TEntity : EntityBase
        where TView : ViewBase
        where TRepo : IRepo<TEntity>
	{
		WebApiResponse<int> Create(TView request);
		WebApiResponse<IQueryable<TView>> ReadAll();
		WebApiResponse<TView> Read(int id);
		WebApiResponse<int> Update(TView request);
		WebApiResponse<int> Delete(int id);
	}
}
