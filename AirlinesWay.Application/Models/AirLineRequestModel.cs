using AirlinesWay.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirlinesWay.Application.Models; 

public class AirLineRequestModel {
	public string Name { get; set; }
	public int Distance { get; set; }

	public int StartedCityId { get; set; }
	public int? IntermediateCityId { get; set; }
	public int FinishedCityId { get; set; }
	public IEnumerable<int> AircompanyIds { get; set; }

	public IEnumerable<SelectListItem> Cities { get; set; }
}