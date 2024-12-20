﻿namespace Freelancely.Infrastructure.Constants
{
    public class DataConstants
    {
        public const int PostTitleMaxLength = 50;

        public const int PostTitleMinLength = 5;

        public const int PostDescriptionMaxLength = 500;

        public const string PostPricePerHour = "decimal(5,2)";

        public const string PostPriceMinValue = "0.01";

        public const string PostPriceMaxValue = "999.99";

        public const int WorkIndustryNameMinLength = 3;

        public const int WorkIndustryNameMaxLength = 50;

        public const int WorkIndustryDescriptionMaxLength = 250;

        public const int EducationMaxLength = 100;

        public const int ReviewMinValue = 1;

        public const int ReviewMaxValue = 5;

        public const int ReviewTextMaxValue = 100;

        public const int GraduationMinYear = 1940;

        public const int GraduationMaxYear = 2024;
    }
}
