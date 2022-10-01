﻿using MedicusApp.Models.Data.Main;
using MedicusApp.Models.Dto.Main;

namespace MedicusApp.Repositories
{
    public interface IMPRepository
    {
        public MainPageDto GetMainPage();
        public bool UpdateAdvantage(AdvantageDto advantage);
    }
}
