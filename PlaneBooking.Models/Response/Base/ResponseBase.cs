namespace PlaneBooking.Models.Response.Base
{
	public abstract class ResponseBase
	{
		public bool Successful { get; set; }
		public int ResponseCode { get; set; }
		public string ErrorMessage { get; set; }
	}
}
