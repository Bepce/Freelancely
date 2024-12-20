﻿using Freelancely.Core.Models.Post;
using Freelancely.Core.Models.WorkIndustry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancely.Core.Contracts.WorkIndustry
{
    public interface IWorkIdustryService
    {
        Task<bool> WorkIndustryExists(string name);

        Task<IEnumerable<PostWorkIndustriesServiceModel>> GetWorkIndustries();

        Task CreateWorkIndustryAsync(WorkIndustryFormModel model); 

        Task UpdateWorkIndustry(WorkIndustryFormModel model, int id);


    }
}
