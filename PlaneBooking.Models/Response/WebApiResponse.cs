using PlaneBooking.Models.Response.Base;

namespace PlaneBooking.Models.Response
{
    public class WebApiResponse<TResult> : ResponseBase
	{
		public TResult Result { get; set; }
	}
}
