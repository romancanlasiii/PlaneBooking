using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlaneBooking.Models.Response;
using PlaneBooking.Models.Entities.Base;
using PlaneBooking.DAL.Repo.Base;
using Microsoft.EntityFrameworkCore;
using PlaneBooking.Models.Views.Base;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace PlaneBooking.WebService.Services.Base
{
	public abstract class CrudServiceBase<TEntity, TView, TRepo> : ICrudServiceBase<TEntity, TView, TRepo>
		where TEntity : EntityBase
        where TView : ViewBase
		where TRepo : IRepo<TEntity>
	{
        #region Member Variables
        private readonly TRepo _Repo;
        private readonly IMapper _Mapper;
        #endregion

        #region Constructor
        protected CrudServiceBase (TRepo repo, IMapper mapper)
		{
			_Repo = repo;
            _Mapper = mapper;
        }
        #endregion

        #region Methods
        public WebApiResponse<int> Create(TView request)
		{
			try
			{
                var entity = _Mapper.Map<TEntity>(request);
                entity.DateCreated = DateTime.Now;
                entity.DateModified = DateTime.Now;
                entity.CreatedBy = request.User;
                entity.ModifiedBy = request.User;

                var resp = _Repo.Add(entity);
				return new WebApiResponse<int>
				{
					Result = resp,
					Successful = true,
					ResponseCode = 0,
					ErrorMessage = string.Empty
				};
			}
			catch (DbUpdateConcurrencyException ex)
			{
				return new WebApiResponse<int>
				{
					Successful = false,
					ResponseCode = 100,
					ErrorMessage = ex.Message
				};
			}
			catch (Exception ex)
			{
				return new WebApiResponse<int>
				{
					Successful = false,
					ResponseCode = 500,
					ErrorMessage = ex.Message
				};
			}
		}

		public WebApiResponse<int> Delete(int id)
		{
			try
			{
				var resp = _Repo.Delete(id);
				return new WebApiResponse<int>
				{
					Result = resp,
					Successful = true,
					ResponseCode = 0,
					ErrorMessage = string.Empty
				};
			}
			catch (Exception ex)
			{
				return new WebApiResponse<int>
				{
					Successful = false,
					ResponseCode = 500,
					ErrorMessage = ex.Message
				};
			}
		}

		public WebApiResponse<TView> Read(int id)
		{
			try
			{
				var respRepo = _Repo.Find(id);
                var resp = _Mapper.Map<TView>(respRepo);
                return new WebApiResponse<TView>
				{
					Result = resp,
					Successful = true,
					ResponseCode = 0,
					ErrorMessage = string.Empty
				};
			}
			catch (Exception ex)
			{
				return new WebApiResponse<TView>
				{
					Successful = false,
					ResponseCode = 500,
					ErrorMessage = ex.Message
				};
			}
			
		}

		public WebApiResponse<IQueryable<TView>> ReadAll()
		{
			try
			{
				var respRepo = _Repo.GetAll();
                var resp = respRepo.Select(e => _Mapper.Map<TEntity, TView>(e));
                return new WebApiResponse<IQueryable<TView>>
				{
					Result = resp,
					Successful = true,
					ResponseCode = 0,
					ErrorMessage = string.Empty
				};
			}
			catch (Exception ex)
			{
				return new WebApiResponse<IQueryable<TView>>
				{
					Successful = false,
					ResponseCode = 500,
					ErrorMessage = ex.Message
				};
			}
		}

		public WebApiResponse<int> Update(TView request)
		{
			try
			{
                var origVal = _Repo.Find(request.Id);

                var entity = _Mapper.Map<TEntity>(request);


                var resp = _Repo.Update(entity);
				return new WebApiResponse<int>
				{
					Result = resp,
					Successful = true,
					ResponseCode = 0,
					ErrorMessage = string.Empty
				};
			}
			catch (DbUpdateConcurrencyException ex)
			{
				return new WebApiResponse<int>
				{
					Successful = false,
					ResponseCode = 100,
					ErrorMessage = ex.Message
				};
				
			}
			catch (Exception ex)
			{
				return new WebApiResponse<int>
				{
					Successful = false,
					ResponseCode = 500,
					ErrorMessage = ex.Message
				};
			}
		}
        #endregion
    }
}
