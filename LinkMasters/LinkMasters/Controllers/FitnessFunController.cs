using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkMasters.Data.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LinkMasters.Controllers
{
    public class FitnessFunController : Controller
    {
        IMuscleGroupRepository _muscleGroupRepository;
        
        public FitnessFunController(IMuscleGroupRepository muscleGroupRepository)
        {
            _muscleGroupRepository = muscleGroupRepository;
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Select()
        {
            ViewData["MuscleGroups"] = _muscleGroupRepository.Muscle_Groups();

            return View();

        }
    }
}