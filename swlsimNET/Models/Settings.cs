﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using swlsimNET.ServerApp.Weapons;
using Microsoft.AspNetCore.Mvc.Rendering;
using swlsimNET.ServerApp.Combat;
using swlsimNET.ServerApp.Spells;
using swlsimNET.ServerApp.Spells.Blood;
using swlsimNET.ServerApp.Spells.Hammer;
using swlsimNET.ServerApp.Spells.Pistol;
using swlsimNET.ServerApp.Spells.Shotgun;

namespace swlsimNET.Models
{
    public class Settings
    {
        [Display(Name = "Primary weapon *")]
        [Required(ErrorMessage = "required.")] // {0} is required. to display name also
        public WeaponType? PrimaryWeapon { get; set; }

        [Display(Name = "Secondary weapon *")]
        [Required(ErrorMessage = "required.")]
        public WeaponType? SecondaryWeapon { get; set; }

        [Display(Name = "Primary weapon affix")]
        public WeaponAffix PrimaryWeaponAffix { get; set; }

        [Display(Name = "Secondary weapon affix")]
        public WeaponAffix SecondaryWeaponAffix { get; set; }
        [Display(Name = "Primary weapon proc")]
        public WeaponProc PrimaryWeaponProc { get; set; }
        [Display(Name = "Secondary weapon proc")]
        public WeaponProc SecondaryWeaponProc { get; set; }

        [Display(Name = "Combat power")]
        public double CombatPower { get; set; } = 1200;

        [Display(Name = "Glance reduction %")]
        public double GlanceReduction { get; set; } = 30;

        [Display(Name = "Critical chance %")]
        public double CriticalChance { get; set; } = 25;

        [Display(Name = "Crit power")]
        public double CritPower { get; set; } = 100;

        [Display(Name = "Basic signet")]
        public double BasicSignet { get; set; } = 75;

        [Display(Name = "Power signet")]
        public double PowerSignet { get; set; } = 17;

        [Display(Name = "Elite signet")]
        public double EliteSignet { get; set; } = 56;
        [Display(Name = "Waist signet")]
        public double WaistSignet { get; set; } = 90;

        [Display(Name = "Action priority list *")]
        [Required(ErrorMessage = "required.")]
        public string Apl { get; set; }

        // Item Bools.
        public bool ColdSilverDice { get; set; } = true;
        public bool GamblersSoul { get; set; } 
        public bool EgonPendant { get; set; }
        public bool SeedOfAgression { get; set; } = true;
        public bool ChokerOfShedBlood { get; set; }
        public bool Ashes { get; set; } = true;
        public bool MnemonicGuardianWerewolf { get; set; }
        public bool ValiMetabolic { get; set; }
        public bool ShardOfSesshoSeki { get; set; } 
        public bool ElectrograviticAttractor { get; set; }

        // Weapon Bools.
        public bool AnimaTouched { get; set; } = true;
        public bool FlameWreathed { get; set; } = false;
        public bool PlasmaForged { get; set; } = false;
        public bool Shadowbound { get; set; } = false;

        public string Passive1 { get; set; }
        public string Passive2 { get; set; }
        public string Passive3 { get; set; }
        public string Passive4 { get; set; }
        public string Passive5 { get; set; }

        public bool OpeningShot { get; set; }
        public bool Exposed { get; set; }
        public bool HeadSignetIsCdr { get; set; }
        public bool Savagery { get; set; }

        public int Iterations { get; set; } = 10;
        public int FightLength { get; set; } = 240;

        public TargetType TargetType { get; set; }

        public IEnumerable<SelectListItem> WeaponTypeList => new SelectList(Enum.GetValues(typeof(WeaponType)));
        public IEnumerable<SelectListItem> WeaponAffixesList => new SelectList(Enum.GetValues(typeof(WeaponAffix)));
        public IEnumerable<SelectListItem> WeaponProcList => new SelectList(Enum.GetValues(typeof(WeaponProc)));
        public IEnumerable<SelectListItem> TargetTypeList => new SelectList(Enum.GetValues(typeof(TargetType)));


        public IEnumerable<SelectListItem> Passives = _allPassives.ConvertAll(
            a => new SelectListItem
        {
            Text = a.ToString().Substring(a.ToString().LastIndexOf('.') + 1),
            Value = a.ToString().Substring(a.ToString().LastIndexOf('.') + 1),
            Selected = false
        });

        public List<Passive> AllPassives => _allPassives;

        private static List<Passive> _allPassives = new List<Passive>
        {
            // TODO: Add ALL passives here

            // Hammer
            new Outrage(),
            new Obliterate(),
            new Berserker(),
            new Annihilate(),
            new UnbridledWrath(),
            new LetLoose(),
            new FastAndFurious(),

            // Pistol
            new FatalShot(),
            new DeadlyDance(),
            new Jackpot(),
            new FixedGame(),
            new HeavyCaliberRounds(),
            new FullyLoaded(),
            new WinStreak(),
            new FlechetteRounds(),
            new BeginnersLuck(),
            new BulletEcho(),
            new Holdout(),

            // Blood
            new CrimsonPulse(),
            new Desolate(),
            new Contaminate(),
            new Flay(),
            new Defilement(),

            // Shotgun
            new SalvageExpert(),
            new PointBlankShot(),
        };
    }
}
