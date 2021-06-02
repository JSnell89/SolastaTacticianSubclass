using SolastaModApi;
using SolastaModApi.Extensions;

namespace SolastaTacticianSubclass
{
    /*********************************************/
    /***************  Feats **********************/
    /*********************************************/

    internal class PowerAttackPowerBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string PowerAttackPowerName = "PowerAttack";
        const string PowerAttackPowerNameGuid = "0a3e6a7d-4628-4189-b91d-d7146d774bb6";

        protected PowerAttackPowerBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionPowers.PowerDomainLifePreserveLife, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&PowerAttackPowerTitle";
            Definition.GuiPresentation.Description = "Feature/&PowerAttackPowerDescription";

            Definition.SetRechargeRate(RuleDefinitions.RechargeRate.AtWill);
            Definition.SetActivationTime(RuleDefinitions.ActivationTime.NoCost);
            Definition.SetShortTitleOverride("Feature/&PowerAttackPowerTitle");
            
            //Create the power attack effect
            EffectForm powerAttackEffect = new EffectForm();
            powerAttackEffect.ConditionForm = new ConditionForm();
            powerAttackEffect.FormType = EffectForm.EffectFormType.Condition;
            powerAttackEffect.ConditionForm.Operation = ConditionForm.ConditionOperation.Add;
            powerAttackEffect.ConditionForm.ConditionDefinition = PowerAttackConditionBuilder.PowerAttackCondition;

            //Add to our new effect
            EffectDescription newEffectDescription = new EffectDescription();
            newEffectDescription.Copy(Definition.EffectDescription);
            newEffectDescription.EffectForms.Clear();
            newEffectDescription.EffectForms.Add(powerAttackEffect);
            newEffectDescription.HasSavingThrow = false;
            newEffectDescription.DurationType = RuleDefinitions.DurationType.Turn;
            newEffectDescription.SetTargetSide(RuleDefinitions.Side.Ally);
            newEffectDescription.SetTargetType(RuleDefinitions.TargetType.Self);
            newEffectDescription.SetCanBePlacedOnCharacter(true);

            Definition.SetEffectDescription(newEffectDescription);
        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new PowerAttackPowerBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower PowerAttackPower
            => CreateAndAddToDB(PowerAttackPowerName, PowerAttackPowerNameGuid);
    }

    internal class PowerAttackTwoHandedPowerBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string PowerAttackTwoHandedPowerName = "PowerAttackTwoHanded";
        const string PowerAttackTwoHandedPowerNameGuid = "b45b8467-7caa-428e-b4b5-ba3c4a153f07";

        protected PowerAttackTwoHandedPowerBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionPowers.PowerDomainElementalLightningBlade, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&PowerAttackTwoHandedPowerTitle";
            Definition.GuiPresentation.Description = "Feature/&PowerAttackTwoHandedPowerDescription";

            Definition.SetRechargeRate(RuleDefinitions.RechargeRate.AtWill);
            Definition.SetActivationTime(RuleDefinitions.ActivationTime.NoCost);
            Definition.SetShortTitleOverride("Feature/&PowerAttackTwoHandedPowerTitle");

            //Create the power attack effect
            EffectForm powerAttackEffect = new EffectForm();
            powerAttackEffect.ConditionForm = new ConditionForm();
            powerAttackEffect.FormType = EffectForm.EffectFormType.Condition;
            powerAttackEffect.ConditionForm.Operation = ConditionForm.ConditionOperation.Add;
            powerAttackEffect.ConditionForm.ConditionDefinition = PowerAttackTwoHandedConditionBuilder.PowerAttackTwoHandedCondition;

            //Add to our new effect
            EffectDescription newEffectDescription = new EffectDescription();
            newEffectDescription.Copy(Definition.EffectDescription);
            newEffectDescription.EffectForms.Clear();
            newEffectDescription.EffectForms.Add(powerAttackEffect);
            newEffectDescription.HasSavingThrow = false;
            newEffectDescription.DurationType = RuleDefinitions.DurationType.Turn;
            newEffectDescription.SetTargetSide(RuleDefinitions.Side.Ally);
            newEffectDescription.SetTargetType(RuleDefinitions.TargetType.Self);
            newEffectDescription.SetCanBePlacedOnCharacter(true);

            Definition.SetEffectDescription(newEffectDescription);
        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new PowerAttackTwoHandedPowerBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower PowerAttackTwoHandedPower
            => CreateAndAddToDB(PowerAttackTwoHandedPowerName, PowerAttackTwoHandedPowerNameGuid);
    }

    internal class PowerAttackOnHandedAttackModifierBuilder : BaseDefinitionBuilder<FeatureDefinitionAttackModifier>
    {
        const string PowerAttackAttackModifierName = "PowerAttackAttackModifier";
        const string PowerAttackAttackModifierNameGuid = "87286627-3e62-459d-8781-ceac1c3462e6";

        protected PowerAttackOnHandedAttackModifierBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionAttackModifiers.AttackModifierFightingStyleArchery, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&PowerAttackAttackModifierTitle";
            Definition.GuiPresentation.Description = "Feature/&PowerAttackAttackModifierDescription";

            //Ideally this would be proficiency but there isn't a nice way to subtract proficiency.
            //To do this properly you could likely make multiple versions of this that get replaced at proficiency level ups but it's a bit of a pain, so going with -3 for now.
            //Originally I made an implemenation that used FeatureDefinitionAdditionalDamage and was going to restrict to melee weapons etc. but really power attack should be avaiable for any build as you choose.
            //The FeatureDefinitionAdditionalDamage was limited in the sense that you couldn't check for things like the 'TwoHanded' or 'Heavy' properties of a weapon so it wasn't worth using really.
            Definition.SetAttackRollModifier(-3);
            Definition.SetDamageRollModifier(3);
        }

        public static FeatureDefinitionAttackModifier CreateAndAddToDB(string name, string guid)
            => new PowerAttackOnHandedAttackModifierBuilder(name, guid).AddToDB();

        public static FeatureDefinitionAttackModifier PowerAttackAttackModifier
            => CreateAndAddToDB(PowerAttackAttackModifierName, PowerAttackAttackModifierNameGuid);
    }

    internal class PowerAttackTwoHandedAttackModifierBuilder : BaseDefinitionBuilder<FeatureDefinitionAttackModifier>
    {
        const string PowerAttackTwoHandedAttackModifierName = "PowerAttackTwoHandedAttackModifier";
        const string PowerAttackTwoHandedAttackModifierNameGuid = "b1b05940-7558-4f03-98d1-01f616b5ae25";

        protected PowerAttackTwoHandedAttackModifierBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionAttackModifiers.AttackModifierFightingStyleArchery, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&PowerAttackTwoHandedAttackModifierTitle";
            Definition.GuiPresentation.Description = "Feature/&PowerAttackTwoHandedAttackModifierDescription";

            //Ideally this would be proficiency but there isn't a nice way to subtract proficiency.
            //To do this properly you could likely make multiple versions of this that get replaced at proficiency level ups but it's a bit of a pain, so going with -3 for now.
            //Originally I made an implemenation that used FeatureDefinitionAdditionalDamage and was going to restrict to melee weapons etc. but really power attack should be avaiable for any build as you choose.
            //The FeatureDefinitionAdditionalDamage was limited in the sense that you couldn't check for things like the 'TwoHanded' or 'Heavy' properties of a weapon so it wasn't worth using really.
            Definition.SetAttackRollModifier(-3);
            Definition.SetDamageRollModifier(6);
        }

        public static FeatureDefinitionAttackModifier CreateAndAddToDB(string name, string guid)
            => new PowerAttackTwoHandedAttackModifierBuilder(name, guid).AddToDB();

        public static FeatureDefinitionAttackModifier PowerAttackTwoHandedAttackModifier
            => CreateAndAddToDB(PowerAttackTwoHandedAttackModifierName, PowerAttackTwoHandedAttackModifierNameGuid);
    }

    //internal class PowerAttackAttackModifierOneHandedBuilderDeprecated : BaseDefinitionBuilder<FeatureDefinitionAdditionalDamage>
    //{
    //    const string PowerAttackAttackModifierOneHandedName = "PowerAttackAttackModifierOneHanded";
    //    const string PowerAttackAttackModifierOneHandedNameGuid = "97d3e384-7fce-403a-9953-dcb5dd54a1e5";

    //    protected PowerAttackAttackModifierOneHandedBuilderDeprecated(string name, string guid) : base(DatabaseHelper.FeatureDefinitionAdditionalDamages.AdditionalDamageBracersOfArchery, name, guid)
    //    {
    //        Definition.GuiPresentation.Title = "Feature/&PowerAttackAttackModifierOneHandedTitle";
    //        Definition.GuiPresentation.Description = "Feature/&PowerAttackAttackModifierOneHandedDescription";
    //        Definition.SetCachedName("Feature/&PowerAttackAttackModifierOneHandedTitle");

    //        //Ideally we could limit the one handed to non-light weapons but I couldn't find a way to do that
    //        //Had a melee weapon restriction originally, but if people want to 'Sharpshoot' with darts or something that's fine with me.
    //        Definition.SetRequiredProperty(RuleDefinitions.AdditionalDamageRequiredProperty.None);
    //        Definition.SetAdditionalDamageType(RuleDefinitions.AdditionalDamageType.SameAsBaseDamage);
    //        Definition.SetDamageDiceNumber(3);
    //        Definition.SetDamageDieType(RuleDefinitions.DieType.D1); //Ha, this doubles on crit, perhaps we can call it a 'feature'.
    //    }

    //    public static FeatureDefinitionAdditionalDamage CreateAndAddToDB(string name, string guid)
    //        => new PowerAttackAttackModifierOneHandedBuilderDeprecated(name, guid).AddToDB();

    //    public static FeatureDefinitionAdditionalDamage PowerAttackAttackModifierOneHanded
    //        => CreateAndAddToDB(PowerAttackAttackModifierOneHandedName, PowerAttackAttackModifierOneHandedNameGuid);
    //}

    //internal class PowerAttackAttackModifierTwoHandedBuilderDeprecated : BaseDefinitionBuilder<FeatureDefinitionAdditionalDamage>
    //{
    //    const string PowerAttackAttackModifierTwoHandedName = "PowerAttackAttackModifierTwoHanded";
    //    const string PowerAttackAttackModifierTwoHandedNameGuid = "a6bb31fd-850e-4a3f-84b2-b298bc0465b0";

    //    protected PowerAttackAttackModifierTwoHandedBuilderDeprecated(string name, string guid) : base(DatabaseHelper.FeatureDefinitionAdditionalDamages.AdditionalDamageBracersOfArchery, name, guid)
    //    {
    //        Definition.GuiPresentation.Title = "Feature/&PowerAttackAttackModifierTwoHandedTitle";
    //        Definition.GuiPresentation.Description = "Feature/&PowerAttackAttackModifierTwoHandedDescription";
    //        Definition.SetCachedName("Feature/&PowerAttackAttackModifierTwoHandedTitle");

    //        //Ideally we could limit the this to actually only be used on two handed weapons (or even 'Heavy' weapons) but I couldn't find a way to do that
    //        //I originally had this limited to melee weapons but I figure the power attack should be applicable to ranged attacks as well to allow a 'sharpshooter' build as well.
    //        Definition.SetRequiredProperty(RuleDefinitions.AdditionalDamageRequiredProperty.None);
    //        Definition.SetAdditionalDamageType(RuleDefinitions.AdditionalDamageType.SameAsBaseDamage);
    //        Definition.SetDamageDiceNumber(6);
    //        Definition.SetDamageDieType(RuleDefinitions.DieType.D1); //Ha, this doubles on crit, perhaps we can call it a 'feature'.
    //    }

    //    public static FeatureDefinitionAdditionalDamage CreateAndAddToDB(string name, string guid)
    //        => new PowerAttackAttackModifierTwoHandedBuilderDeprecated(name, guid).AddToDB();

    //    public static FeatureDefinitionAdditionalDamage PowerAttackAttackModifierTwoHanded
    //        => CreateAndAddToDB(PowerAttackAttackModifierTwoHandedName, PowerAttackAttackModifierTwoHandedNameGuid);
    //}

    internal class PowerAttackConditionBuilder : BaseDefinitionBuilder<ConditionDefinition>
    {
        const string PowerAttackConditionName = "PowerAttackCondition";
        const string PowerAttackConditionNameGuid = "c125b7b9-e668-4c6f-a742-63c065ad2292";

        protected PowerAttackConditionBuilder(string name, string guid) : base(DatabaseHelper.ConditionDefinitions.ConditionHeraldOfBattle, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&PowerAttackConditionTitle";
            Definition.GuiPresentation.Description = "Feature/&PowerAttackConditionDescription";

            Definition.SetAllowMultipleInstances(false);
            Definition.Features.Clear();
            Definition.Features.Add(PowerAttackOnHandedAttackModifierBuilder.PowerAttackAttackModifier);

            Definition.SetDurationType(RuleDefinitions.DurationType.Turn);
        }

        public static ConditionDefinition CreateAndAddToDB(string name, string guid)
            => new PowerAttackConditionBuilder(name, guid).AddToDB();

        public static ConditionDefinition PowerAttackCondition
            => CreateAndAddToDB(PowerAttackConditionName, PowerAttackConditionNameGuid);
    }

    internal class PowerAttackTwoHandedConditionBuilder : BaseDefinitionBuilder<ConditionDefinition>
    {
        const string PowerAttackTwoHandedConditionName = "PowerAttackTwoHandedCondition";
        const string PowerAttackTwoHandedConditionNameGuid = "7d0eecbd-9ad8-4915-a3f7-cfa131001fe6";

        protected PowerAttackTwoHandedConditionBuilder(string name, string guid) : base(DatabaseHelper.ConditionDefinitions.ConditionHeraldOfBattle, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&PowerAttackTwoHandedConditionTitle";
            Definition.GuiPresentation.Description = "Feature/&PowerAttackTwoHandedConditionDescription";

            Definition.SetAllowMultipleInstances(false);
            Definition.Features.Clear();
            Definition.Features.Add(PowerAttackTwoHandedAttackModifierBuilder.PowerAttackTwoHandedAttackModifier);

            Definition.SetDurationType(RuleDefinitions.DurationType.Turn);
        }

        public static ConditionDefinition CreateAndAddToDB(string name, string guid)
            => new PowerAttackTwoHandedConditionBuilder(name, guid).AddToDB();

        public static ConditionDefinition PowerAttackTwoHandedCondition
            => CreateAndAddToDB(PowerAttackTwoHandedConditionName, PowerAttackTwoHandedConditionNameGuid);
    }

    internal class PowerAttackFeatBuilder : BaseDefinitionBuilder<FeatDefinition>
    {
        const string PowerAttackFeatName = "PowerAttackFeat";
        const string PowerAttackFeatNameGuid = "88f1fb27-66af-49c6-b038-a38142b1083e";

        protected PowerAttackFeatBuilder(string name, string guid) : base(DatabaseHelper.FeatDefinitions.FollowUpStrike, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&PowerAttackFeatTitle";
            Definition.GuiPresentation.Description = "Feat/&PowerAttackFeatDescription";

            Definition.Features.Clear();
            Definition.Features.Add(PowerAttackPowerBuilder.PowerAttackPower);
            Definition.Features.Add(PowerAttackTwoHandedPowerBuilder.PowerAttackTwoHandedPower);
            Definition.SetMinimalAbilityScorePrerequisite(false);
        }

        public static FeatDefinition CreateAndAddToDB(string name, string guid)
            => new PowerAttackFeatBuilder(name, guid).AddToDB();

        public static FeatDefinition PowerAttackFeat
            => CreateAndAddToDB(PowerAttackFeatName, PowerAttackFeatNameGuid);

        public static void AddToFeatList()
        {
            var powerAttackFeat = PowerAttackFeatBuilder.PowerAttackFeat;//Instantiating it adds to the DB
        }
    }
}
