﻿using MaterialDesignThemes.Wpf;
using MaterialForms.Wpf.Annotations;

namespace MaterialForms.Demo.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum AgeGroup
    {
        [EnumDisplay("0-18")]
        ZeroToEighteen,
        [EnumDisplay("18-39")]
        EighteenToThirtyNine,
        [EnumDisplay("40+")]
        FortyPlus
    }

    public enum YesNo
    {
        Yes,
        No
    }

    public class Selection
    {
        [SelectFrom(typeof(Gender), SelectionType = SelectionType.RadioButtons)]
        public Gender? Gender { get; set; }

        [SelectFrom(typeof(AgeGroup))]
        public AgeGroup AgeGroup { get; set; }

        [Field(Icon = PackIconKind.Star)]
        [SelectFrom(new[] { "Fantastic", "Good", "Average", "Bad" })]
        public string RateThisFeature { get; set; }

        [SelectFrom("{Binding Seats}", SelectionType = SelectionType.ComboBoxEditable)]
        public int NumberOfSeats { get; set; }

        [SelectFrom(typeof(YesNo?))]
        public YesNo? DeselectMe { get; set; } = YesNo.Yes;

        public int[] Seats => new[] { 1, 2, 3, 4 };
    }
}
