// Import necessary libraries

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SavePoint.Models
{
    public class Games
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(60)]
        public string Title { get; set; }

        [Display(Name = "Console")]
        [Required(ErrorMessage = "Please select a Console from the Drop Down")]
        public Consoles Consoles { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Please select a Genre from the Drop Down")]
        public Genre Genre { get; set; }
        
        [Display(Name = "Release Year")]
        [Range(1900, 2100)]
        public int ReleaseYear { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [StringLength(300, MinimumLength = 2)]
        public string Comment { get; set; }

    }

    // Drop Down List values for Console variable

    public enum Consoles
    {
 
        NES,
        SNES,
        N64,

        GameCube,

        Wii,

        [Display(Name = "Wii U")]
        WiiU,

        GameBoy,

        [Display(Name = "GameBoy Advance")]
        GameboyAdvance,

        DS,

        [Display(Name = "3DS")]
        ThreeDS,

        Genesis,

        Saturn,

        Dreamcast,

        Playstation,

        [Display(Name = "Playstation 2")]
        Playstation2,

        [Display(Name = "Playstation 3")]
        Playstation3,

        [Display(Name = "Playstation 4")]
        Playstation4,

        Vita,

        [Display(Name = "XBox")]
        Xbox,

        [Display(Name = "XBox 360")]
        Xbox360,

        [Display(Name = "XBox One")]
        Xboxone,

        PC,

    }

    // Drop Down List values for Type variable

    public enum Genre
    {

        [Display(Name = "Action/Adventure")]
        ActionAdventure,

        [Display(Name = "Role Playing")]
        RPG,

        [Display(Name = "First Person Shooter")]
        FPS,

        Strategy,

        [Display(Name = "Music/Dance")]
        MusicDance,

    }
}
