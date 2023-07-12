using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackRevival.Common.Model
{
    public enum ProductName
    {
        // Token: 0x04005401 RID: 21505
        NONE,
        // Token: 0x04005402 RID: 21506
        GOLD_5600,
        // Token: 0x04005403 RID: 21507
        GOLD_31500,
        // Token: 0x04005404 RID: 21508
        GOLD_70000,
        // Token: 0x04005405 RID: 21509
        GOLD_154000,
        // Token: 0x04005406 RID: 21510
        GEM_250,
        // Token: 0x04005407 RID: 21511
        GEM_500,
        // Token: 0x04005408 RID: 21512
        GEM_1200,
        // Token: 0x04005409 RID: 21513
        GEM_2500,
        // Token: 0x0400540A RID: 21514
        GEM_6500,
        // Token: 0x0400540B RID: 21515
        GEM_14000,
        // Token: 0x0400540C RID: 21516
        GEM_80,
        // Token: 0x0400540D RID: 21517
        BEGINNERS_PACK,
        // Token: 0x0400540E RID: 21518
        CHARACTER_PACK,
        // Token: 0x0400540F RID: 21519
        CHARACTER_PACK2,
        // Token: 0x04005410 RID: 21520
        NEW_CHARACTER_PACK,
        // Token: 0x04005411 RID: 21521
        LEAGUE_UP_HORSE,
        // Token: 0x04005412 RID: 21522
        LEAGUE_UP_BUFFALO,
        // Token: 0x04005413 RID: 21523
        LEAGUE_UP_ELEPHANT,
        // Token: 0x04005414 RID: 21524
        LEAGUE_UP_FOX,
        // Token: 0x04005415 RID: 21525
        LEAGUE_UP_WOLF,
        // Token: 0x04005416 RID: 21526
        LEAGUE_UP_LION,
        // Token: 0x04005417 RID: 21527
        LEAGUE_UP_BEAR,
        // Token: 0x04005418 RID: 21528
        LEAGUE_UP_DRAGON,
        // Token: 0x04005419 RID: 21529
        GOLD_BOOSTER_GAME_10,
        // Token: 0x0400541A RID: 21530
        GOLD_BOOSTER_GAME_100,
        // Token: 0x0400541B RID: 21531
        GOLD_BOOSTER_TIME_24H,
        // Token: 0x0400541C RID: 21532
        GOLD_BOOSTER_TIME_240H,
        // Token: 0x0400541D RID: 21533
        LEAGUE_RANK_BOOSTER_GAME_10,
        // Token: 0x0400541E RID: 21534
        LEAGUE_RANK_BOOSTER_GAME_100,
        // Token: 0x0400541F RID: 21535
        LEAGUE_RANK_BOOSTER_TIME_24H,
        // Token: 0x04005420 RID: 21536
        LEAGUE_RANK_BOOSTER_TIME_240H,
        // Token: 0x04005421 RID: 21537
        REVIVE_1000,
        // Token: 0x04005422 RID: 21538
        NICKNAME_CHANGE,
        // Token: 0x04005423 RID: 21539
        RESEARCH_SUPPORT,
        // Token: 0x04005424 RID: 21540
        EXPERT_RESEARCH_SUPPORT,
        // Token: 0x04005425 RID: 21541
        TOURNAMENT_TICKET_SUPPORT,
        // Token: 0x04005426 RID: 21542
        POTENTIAL_SKILL_FINDBREAD,
        // Token: 0x04005427 RID: 21543
        POTENTIAL_SKILL_AMBUSH,
        // Token: 0x04005428 RID: 21544
        POTENTIAL_SKILL_DETECT,
        // Token: 0x04005429 RID: 21545
        POTENTIAL_SKILL_COUNTER,
        // Token: 0x0400542A RID: 21546
        POTENTIAL_SKILL_ACCELATE,
        // Token: 0x0400542B RID: 21547
        POTENTIAL_SKILL_FINDBULLET,
        // Token: 0x0400542C RID: 21548
        POTENTIAL_SKILL_FINDARROW,
        // Token: 0x0400542D RID: 21549
        POTENTIAL_SKILL_CHASE,
        // Token: 0x0400542E RID: 21550
        POTENTIAL_SKILL_PROVOKE,
        // Token: 0x0400542F RID: 21551
        POTENTIAL_SKILL_ADAPTATION,
        // Token: 0x04005430 RID: 21552
        POTENTIAL_SKILL_WIDE_HEAL,
        // Token: 0x04005431 RID: 21553
        POTENTIAL_SKILL_POACH,
        // Token: 0x04005432 RID: 21554
        POTENTIAL_SKILL_FEVER,
        // Token: 0x04005433 RID: 21555
        POTENTIAL_SKILL_RESTORATION,
        // Token: 0x04005434 RID: 21556
        LIGHT_LUNCH_BOX,
        // Token: 0x04005435 RID: 21557
        SUPPLY_BOX_OFFENCE,
        // Token: 0x04005436 RID: 21558
        SUPPLY_BOX_DEFENCE,
        // Token: 0x04005437 RID: 21559
        ICE_BOX,
        // Token: 0x04005438 RID: 21560
        INVENTORY_EXTENDER,
        // Token: 0x04005439 RID: 21561
        OBSERVER,
        // Token: 0x0400543A RID: 21562
        DALIY_CHARACTER_EXP,
        // Token: 0x0400543B RID: 21563
        DALIY_GOLD_1000,
        // Token: 0x0400543C RID: 21564
        DALIY_EM_3,
        // Token: 0x0400543D RID: 21565
        RANDOM_DNA,
        // Token: 0x0400543E RID: 21566
        DAILY_GEM_FROM_LABYRINTH_POINT_1,
        // Token: 0x0400543F RID: 21567
        DAILY_GEM_FROM_LABYRINTH_POINT_2,
        // Token: 0x04005440 RID: 21568
        DAILY_GEM_FROM_LABYRINTH_POINT_3,
        // Token: 0x04005441 RID: 21569
        SEASON_VOTE_BY_GEM_1,
        // Token: 0x04005442 RID: 21570
        SEASON_VOTE_BY_GOLD_1,
        // Token: 0x04005443 RID: 21571
        SEASON_VOTE_BY_BEAR_POINT_1,
        // Token: 0x04005444 RID: 21572
        SEASON_VOTE_BY_GEM_10,
        // Token: 0x04005445 RID: 21573
        SEASON_VOTE_BY_GOLD_10,
        // Token: 0x04005446 RID: 21574
        SEASON_VOTE_BY_BEAR_POINT_10,
        // Token: 0x04005447 RID: 21575
        SEASON_VOTE_BY_GEM_100,
        // Token: 0x04005448 RID: 21576
        SEASON_VOTE_BY_GOLD_100,
        // Token: 0x04005449 RID: 21577
        SEASON_VOTE_BY_BEAR_POINT_100,
        // Token: 0x0400544A RID: 21578
        EXPERIMENT_MEMORY_500,
        // Token: 0x0400544B RID: 21579
        EXPERIMENT_MEMORY_2000,
        // Token: 0x0400544C RID: 21580
        EXPERIMENT_MEMORY_5000,
        // Token: 0x0400544D RID: 21581
        TOURNAMENT_TICKET_1,
        // Token: 0x0400544E RID: 21582
        TOURNAMENT_TICKET_10,
        // Token: 0x0400544F RID: 21583
        NICKNAME_CHANGE_TICKET,
        // Token: 0x04005450 RID: 21584
        PVE_CHARGE_TICKET_01,
        // Token: 0x04005451 RID: 21585
        PVE_FREE_TICKET_01,
        // Token: 0x04005452 RID: 21586
        LABYRINTH_MEMBERSHIP,
        // Token: 0x04005453 RID: 21587
        LABYRINTH_BOOSTER,
        // Token: 0x04005454 RID: 21588
        JACKIE_ACTUATION_PACK_01,
        // Token: 0x04005455 RID: 21589
        FIORA_ACTUATION_PACK_01,
        // Token: 0x04005456 RID: 21590
        ZAHIR_ACTUATION_PACK_01,
        // Token: 0x04005457 RID: 21591
        HYUNWOO_ACTUATION_PACK_01,
        // Token: 0x04005458 RID: 21592
        JENNY_ACTUATION_PACK_01,
        // Token: 0x04005459 RID: 21593
        JP_ACTUATION_PACK_01,
        // Token: 0x0400545A RID: 21594
        NADINE_ACTUATION_PACK_01,
        // Token: 0x0400545B RID: 21595
        AYA_ACTUATION_PACK_01,
        // Token: 0x0400545C RID: 21596
        HYEJIN_ACTUATION_PACK_01,
        // Token: 0x0400545D RID: 21597
        ALEX_ACTUATION_PACK_01,
        // Token: 0x0400545E RID: 21598
        CATHY_ACTUATION_PACK_01,
        // Token: 0x0400545F RID: 21599
        BARBARA_ACTUATION_PACK_01,
        // Token: 0x04005460 RID: 21600
        ISOL_ACTUATION_PACK_01,
        // Token: 0x04005461 RID: 21601
        SILVIA_ACTUATION_PACK_01,
        // Token: 0x04005462 RID: 21602
        CHIARA_ACTUATION_PACK_01,
        // Token: 0x04005463 RID: 21603
        HART_ACTUATION_PACK_01,
        // Token: 0x04005464 RID: 21604
        SHOICHI_ACTUATION_PACK_01,
        // Token: 0x04005465 RID: 21605
        ARDA_ACTUATION_PACK_01,
        // Token: 0x04005466 RID: 21606
        CAMILO_ACTUATION_PACK_01,
        // Token: 0x04005467 RID: 21607
        BERNICE_ACTUATION_PACK_01,
        // Token: 0x04005468 RID: 21608
        SISSELA_ACTUATION_PACK_01,
        // Token: 0x04005469 RID: 21609
        ADELA_ACTUATION_PACK_01,
        // Token: 0x0400546A RID: 21610
        ADRIANA_ACTUATION_PACK_01,
        // Token: 0x0400546B RID: 21611
        NATHAPON_ACTUATION_PACK_01,
        // Token: 0x0400546C RID: 21612
        YUKI_ACTUATION_PACK_01,
        // Token: 0x0400546D RID: 21613
        LENOX_ACTUATION_PACK_01,
        // Token: 0x0400546E RID: 21614
        SUA_ACTUATION_PACK_01,
        // Token: 0x0400546F RID: 21615
        MAI_ACTUATION_PACK_01,
        // Token: 0x04005470 RID: 21616
        JAN_ACTUATION_PACK_01,
        // Token: 0x04005471 RID: 21617
        LUKE_ACTUATION_PACK_01,
        // Token: 0x04005472 RID: 21618
        DANIEL_ACTUATION_PACK_01,
        // Token: 0x04005473 RID: 21619
        RIO_ACTUATION_PACK_01,
        // Token: 0x04005474 RID: 21620
        EVA_ACTUATION_PACK_01,
        // Token: 0x04005475 RID: 21621
        NICKY_ACTUATION_PACK_01,
        // Token: 0x04005476 RID: 21622
        DAILY_PACK_A,
        // Token: 0x04005477 RID: 21623
        DAILY_PACK_B,
        // Token: 0x04005478 RID: 21624
        DAILY_PACK_C,
        // Token: 0x04005479 RID: 21625
        YUKI_FIRSTIAP_PACK_01,
        // Token: 0x0400547A RID: 21626
        SUA_FIRSTIAP_PACK_01,
        // Token: 0x0400547B RID: 21627
        MAI_FIRSTIAP_PACK_01
    }
}
