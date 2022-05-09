using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirlinesWay.Application.Models; 

public class CitiesResponseModel {
	public int StartedCityId { get; set; }
	public int FinishedCityId { get; set; }
	public int FilterType { get; set; }

	public List<SelectListItem> Cities = new List<SelectListItem>();
}