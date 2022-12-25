namespace AphoPassivePack
{
    public class PassiveAbility_Apho_DeeperBreaths : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            if (RandomUtil.valueForProb < 0.5f)
            {
                this.owner.ShowPassiveTypo(this);
                this.owner.cardSlotDetail.RecoverPlayPoint(1);
            }
        }
    }
    public class PassiveAbility_Apho_DeepestBreaths : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            this.owner.ShowPassiveTypo(this);
            this.owner.cardSlotDetail.RecoverPlayPoint(1);
        }
    }
    public class PassiveAbility_Apho_Underbreathing : PassiveAbilityBase
    {
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            if (curCard.card.GetOriginCost() <= 3)
            {
                this.owner.cardSlotDetail.RecoverPlayPoint(2);
            }
        }
    }
    public class PassiveAbility_Apho_DeathlyBreathing : PassiveAbilityBase
    {
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            if (curCard.card.GetOriginCost() == 4)
            {
                this.owner.cardSlotDetail.RecoverPlayPoint(4);
            }
        }
    }

    public class PassiveAbility_Apho_EmergencyBreathingProtocol : PassiveAbilityBase
    {
        public override void OnRoundEnd()
        {
            BattleUnitBuf_warpCharge battleUnitBuf_warpCharge = this.owner.bufListDetail.GetActivatedBuf(KeywordBuf.WarpCharge) as BattleUnitBuf_warpCharge;
            if (this.owner.cardSlotDetail.PlayPoint <= 0 && battleUnitBuf_warpCharge.stack > 0)
            {
                this.owner.cardSlotDetail.RecoverPlayPoint(battleUnitBuf_warpCharge.stack / 5);
                battleUnitBuf_warpCharge.UseStack(battleUnitBuf_warpCharge.stack, false);
                
            }
        }
    }
    public class PassiveAbility_Apho_FireBreathing : PassiveAbilityBase
    {
        public override void OnRoundEnd()
        {
            BattleUnitBuf_warpCharge battleUnitBuf_warpCharge = this.owner.bufListDetail.GetActivatedBuf(KeywordBuf.WarpCharge) as BattleUnitBuf_warpCharge;
            if (this.owner.cardSlotDetail.PlayPoint <= 0 && battleUnitBuf_warpCharge.stack > 4)
            {
                this.owner.ShowPassiveTypo(this);
                this.owner.cardSlotDetail.RecoverPlayPoint(battleUnitBuf_warpCharge.stack / 5);
                battleUnitBuf_warpCharge.UseStack(battleUnitBuf_warpCharge.stack, false);
            }
        }
        public override void OnRoundStart()
        {
            BattleUnitBuf_burn battleUnitBuf_Burn = this.owner.bufListDetail.GetActivatedBuf(KeywordBuf.Burn) as BattleUnitBuf_burn;
            if (battleUnitBuf_Burn.stack > 9)
            {
                this.owner.ShowPassiveTypo(this);
                this.owner.cardSlotDetail.RecoverPlayPoint(battleUnitBuf_Burn.stack / 10);
            }
        }
    }
}
