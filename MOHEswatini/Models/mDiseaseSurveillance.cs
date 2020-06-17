using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MOHEswatini.Models
{
    [Table("T_DiseaseSurveillance")]
    public class mDiseaseSurveillance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public int iID { get; set; }

        [Column("dArrivalDate", TypeName = "datetime")]
        [Display(Name = "Arrival Date")]
        [Required(ErrorMessage = "The Arrival Date Is Required")]
        public DateTime? ArrivalDate { get; set; }


        [Column("cArrivedBy", TypeName = "varchar(50)")]
        [Display(Name = "Arrived By")]
        [Required(ErrorMessage = "The Arrived By is required")]

        [StringLength(50)]
        public string ArrivedBy { get; set; }

        [Column("cVehicleNo", TypeName = "varchar(50)")]
        [Display(Name = "Vehicle No")]
        [Required(ErrorMessage = "The Vehicle No is required")]
        [StringLength(50)]
        public string VehicleNo { get; set; }

        [Column("cPointOfEntry", TypeName = "varchar(100)")]
        [Display(Name = "Point Of Entry")]
        [Required(ErrorMessage = "The Point Of Entry is required")]
        [StringLength(100)]
        public string PointOfEntry { get; set; }

        [Column("cSeatNo", TypeName = "varchar(10)")]
        [Display(Name = "SeatNo")]
        [StringLength(10)]
        public string SeatNo { get; set; }
        [Column("cName", TypeName = "varchar(100)")]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "The Name is required")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column("cContactNo", TypeName = "varchar(30)")]
        [Display(Name = "Contact No")]
        [Required(ErrorMessage = "The Contact No is required")]
        [StringLength(30)]
        public string ContactNo { get; set; }

        [Column("cPassportNo", TypeName = "varchar(10)")]
        [Display(Name = "Passport No")]
        [Required(ErrorMessage = "The Passport No is required")]
        [StringLength(maximumLength: 10, MinimumLength = 10)]
        public string PassportNo { get; set; }

        [Column("cAge", TypeName = "varchar(10)")]
        [Display(Name = "Age in Year")]
        [Required(ErrorMessage = "The Age is required")]
        [StringLength(10)]
        public string Age { get; set; }

        [Column("cGender", TypeName = "varchar(10)")]
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "The Gender is required")]
        [StringLength(10)]
        public string Gender { get; set; }

        [Column("cRecentlyVisitedCountry1", TypeName = "varchar(20)")]
        [Display(Name = "Recently Visited Country-1")]
        //[Required(ErrorMessage = "The Recently Visited Country - 1 is required")]
        [StringLength(20)]
        public string RecentlyVisitedCountry1 { get; set; }

        [Column("cNoOfDaysSpend1", TypeName = "int")]
        [Display(Name = "No Of Days Spend - 1")]
       // [Required(ErrorMessage = "The No Of Days Spend - 1 is required")]
        public int? NoOfDaysSpend1 { get; set; }

        [Column("cRecentlyVisitedCountry2", TypeName = "varchar(20)")]
        [Display(Name = "Recently Visited Country-2")]
        //[Required(ErrorMessage = "The Recently Visited Country - 2 is required")]
        [StringLength(20)]
        public string RecentlyVisitedCountry2 { get; set; }

        [Column("cNoOfDaysSpend2", TypeName = "int")]
        [Display(Name = "No Of Days Spend - 2")]
        //[Required(ErrorMessage = "The No Of Days Spend - 2 is required")]
        public int? NoOfDaysSpend2 { get; set; }

        [Column("cRecentlyVisitedCountry3", TypeName = "varchar(20)")]
        [Display(Name = "Recently Visited Country-3")]
        //[Required(ErrorMessage = "The Recently Visited Country - 3 is required")]
        [StringLength(20)]
        public string RecentlyVisitedCountry3 { get; set; }

        [Column("cNoOfDaysSpend3", TypeName = "int")]
        [Display(Name = "No Of Days Spend - 3")]
        //[Required(ErrorMessage = "The No Of Days Spend - 3 is required")]
        public int? NoOfDaysSpend13 { get; set; }

        [Column("cRecentlyVisitedCountry4", TypeName = "varchar(20)")]
        [Display(Name = "Recently Visited Country-4")]
       // [Required(ErrorMessage = "The Recently Visited Country - 4 is required")]
        [StringLength(20)]
        public string RecentlyVisitedCountry4 { get; set; }

        [Column("cNoOfDaysSpend4", TypeName = "int")]
        [Display(Name = "No Of Days Spend - 4")]
       // [Required(ErrorMessage = "The No Of Days Spend - 4 is required")]
        public int? NoOfDaysSpend4 { get; set; }

        [Column("cPhysicalAddress", TypeName = "varchar(500)")]
        [Display(Name = "Physical Address")]
        [Required(ErrorMessage = "The Physical Address is required")]
        [StringLength(500)]
        public string PhysicalAddress { get; set; }

        [Column("cPhysicalContactNo", TypeName = "varchar(30)")]
        [Display(Name = "Contact No")]
        [Required(ErrorMessage = "The Contact No is required")]
        [StringLength(30)]
        public string PhysicalContactNo { get; set; }

        [Column("cCountryOfResidence", TypeName = "varchar(100)")]
        [Display(Name = "Country Of Residence")]
        [Required(ErrorMessage = "The Country Of Residence is required")]
        [StringLength(100)]
        public string CountryOfResidence { get; set; }

        [Column("lHeadache", TypeName = "bit")]
        [Display(Name = "Headache")]
        public bool Headache { get; set; }

        [Column("lBleeding", TypeName = "bit")]
        [Display(Name = "Bleeding(With No Injury")]
        public bool Bleeding { get; set; }

        [Column("lFever", TypeName = "bit")]
        [Display(Name = "Fever")]
        public bool Fever { get; set; }

        [Column("lCough", TypeName = "bit")]
        [Display(Name = "Cough")]
        public bool Cough { get; set; }

        [Column("lGeneralBodyPain", TypeName = "bit")]
        [Display(Name = "General Body Pain")]
        public bool GeneralBodyPain { get; set; }

        [Column("lDiarrhea", TypeName = "bit")]
        [Display(Name = "Diarrhea(Bloody)")]
        public bool Diarrhea { get; set; }

        [Column("lVomiting", TypeName = "bit")]
        [Display(Name = "Vomiting")]
        public bool Vomiting { get; set; }

        [Column("lSoreThroat", TypeName = "bit")]
        [Display(Name = "Sore Throat")]
        public bool SoreThroat { get; set; }

        [Column("lPolio", TypeName = "bit")]
        [Display(Name = "Polio")]
        public bool Polio { get; set; }

        [Column("lYellowFever", TypeName = "bit")]
        [Display(Name = "Yellow Fever")]
        public bool YellowFever { get; set; }

        [Column("lMalaria", TypeName = "bit")]
        [Display(Name = "Malaria")]
        public bool Malaria { get; set; }

        [Column("lOthers", TypeName = "bit")]
        [Display(Name = "Others")]
        public bool Others { get; set; }

        [Column("cOthersVaccine", TypeName = "varchar(30)")]
        [Display(Name = "Others Vaccine")]
        [StringLength(30)]
        public string OthersVaccine { get; set; }

        [Column("cHealthFacility", TypeName = "varchar(100)")]
        [Display(Name = "Nearest Health Facility In Swaziland(if Known)")]
        [StringLength(100)]
        public string HealthFacility { get; set; }

        [Column("lCovidTested", TypeName = "bit")]
        [Display(Name = "Is Covid-19 Tested")]
        public bool CovidTested { get; set; }

        [Column("dCovidTestingDate", TypeName = "datetime")]
        [Display(Name = "Covid-19 Testing Date")]
        public DateTime? CovidTestingDate { get; set; }

        [Column("cCovidTestingLab", TypeName = "varchar(100)")]
        [Display(Name = "Covid-19 Testing Lab Name And Address")]
        [StringLength(100)]
        public string CovidTestingLab { get; set; }

        [Column("cCovidTestingKitNo", TypeName = "varchar(50)")]
        [Display(Name = "Covid-19 Testing Kit No(if Known)")]
        [StringLength(50)]
        public string CovidTestingKitNo { get; set; }



        [Column("cCovidTestResult", TypeName = "varchar(50)")]
        [Display(Name = "Covid-19 Test Result")]
        [StringLength(50)]
        public string CovidTestResult { get; set; }
    }
}
