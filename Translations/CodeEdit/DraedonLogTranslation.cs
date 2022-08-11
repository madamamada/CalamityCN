﻿using CalamityMod.NPCs.TownNPCs;
using CalamityMod.UI;
using MonoMod.RuntimeDetour;
using System.Collections.Generic;
using Terraria.Localization;

namespace CalamityCN.Translations.CodeEdit
{
    public class DraedonLogTranslation
    {
        private static List<Hook> logHooks;
        private static string[] logContent = new string[]
        {
            // 地狱
            "整个环境就是一个可以源源不断提供地热和锻造厂需要的热能的能量来源。要不是这里完全不适合除了恶魔和灵魂以外的任何人居住，或许我还会在地底进行更多的研究。然而，我绝对不会选择去定居的地方，是在地狱的峭壁上。在那里，岩浆非常……深闭固拒，而且腐蚀性比理论上的可能要强得多。毕竟那里充满了由那个女巫造成的，被诅咒扭曲的灵魂。",
            "这个融合造物，是多么可怕，却又多么诱人。与萦绕在地牢中的灵魂所融合形成的造物不同，这个生物并非是一个人，而是由众多有罪者组成的。然而对它而言不同的是，地牢存在的人为性所造成的限制并不适用于它。是地狱的法则将他们聚集在一起，成为地下世界的霸主。而当一条条无辜的生命被牺牲时……他们的饥饿感似乎与来世相通一般，汹涌澎湃。",
            "这把刀，在我创造它的时候，它完全被我的周围环境所淹没。它由灵魂燃烧所形成的火焰淬炼，在我引入实验室中的岩浆里锻造而成。它的边锋无比锋利，尽管它的挥动范围有限，使得它能否可以正常使用遭到了质疑。我愿意把它看作是我为了工艺和艺术而进行的第一次工作。假如我是被人工制造出来的，那么任何能让人怀疑这一点的作品，它都是可以让我引以为豪的作品。也就是说，无论如何，我还可以承蒙灵感的恩惠。",
            // 丛林
            "在我记录下这段话的时候，称丛林为这个星球的中心并不为过。一切都以它为中心，它无人不知无人不晓。当我看到那些在丛林上方经过的生物的那些令人厌恶的、原始而落后的形态时，让我产生了不少的反感。幸运的是，这些实验室提供了我研究中所需要的一切，甚至还要多。除非是领主亲自下命令传唤我以外，我再也没有了去地表参观的必要。",
            "一种能够吞噬和转化几乎一切的病毒，和为了控制它而精心构造的纳米病毒。这东西发展的速度非常快，而每一块被它污染的地方，几乎都诡异地形成了一种令人恐惧的存在。我很难想出任何它能对正常生命体友好的应用方法。然而这并不是一个主要的问题。许多人对是否应该继续对它的创造感到犹豫不决，然而我准许了他们，只要他们想，他们就可以离开。毕竟，我根本不需要任何没有我的机器那样专一的人。",
            "我之前做过实验的那个蜂后，在经过了机械强化后，理论上应该是瘟疫病毒的完美宿主。然而当科技与生物结合的第一个里程碑诞生时，问题也立刻显现出来。昆虫的思维开始对抗纳米技术的控制，这点与我之前用作实验品的那些简单生物完全不同。它变得越来越暴戾，只有在被驯服后才开始接受简单的命令。然而，如果我们想要完全发挥它的作用，除了完全放任它自由自在的游荡以外别无他法。我会进一步思考这个问题。",
            // 小行星
            "这些悬挂在低轨道上的，大量且遍布世界各地的球体为我提供了一个隐蔽而遥远的研究点。无可否认，对于天文学和其他方面的科学来说，这里是最佳的地点。在我在这儿的实验室里，我种植了许多东西，以测试它们在在平流层的寒冷和真空中的极限。虽然存活下来的植株不多，但这个地方某些生物的存在，证实了只要提供更多的时间，生命就能在此存活。",
            "我对星际，或者说宇宙并不怎么关心。虽然我曾经在其中穿越过，但此时此刻，在我自己的世界里，依然还有很多东西需要我去管理和发现。就算我曾经居住在不同的星球上，但领主希望我为他提供机械，是我需要离开那儿到其他地方定居的唯一条件。一旦我发现并剖析了这颗星球的每一处奥秘，也许在那之后，我才会抬头看向那片宏伟的寰宇。",
            "那条臃肿的宇宙巨虫，虽然我明白领主能控制它并使用它，可它对我而言，依然是个令我讨厌的存在。然而，创造一件在各方面都适合它的装甲的提案，并不容我拒绝。这件装甲由我自己创造的宇宙钢锻造而成，能几乎抵御住任何攻击，但又能让这个生物保持和没有装甲时一样的灵活性，同时还能增强它的维度能力。不管怎么说，我对这个结果仍然很满意。",
            // 雪原
            "在这片冰天雪地的冻土地带，只有完全适应零下温度的生物才能在这里存在和繁衍。从纯净的森林到被阳光烘烤的沙漠，气候的转变令人震惊。像这样的气候不应该会轻易地在这样的地方自然存在。在这些冰雪平原天空的周围，天气模式的转变似乎也很不自然。这很可能是有原因的，有必要进行进一步研究。",
            "令人好奇。尽管深埋在冰洞中，还因为几个世纪的冰霜和融水而变得破旧不堪，但我依然发现了几个曾经遍布于这些隧道的装置。这些独创的装置非凡无比，我不仅在自己的作品中发现了和这些装置的相似之处，甚至还有一些连我自己都需要向其学习的装置。这些东西从何而来？为什么在如此稀疏和沉闷的地层里会有如此复杂的机械？也许，它们与非自然条件有关。",
            "我并不是唯一一个居住在这个生物群落的独行侠。曾经，反对领主的大法师也居住在这里，被他自己创造的持续不断的人造暴风雪所保护，而这些暴风雪现在已经消失。他很可能选择了这里作为研究他的冰系法术的渠道，并延长了这里保持冰封的时间。在地底深处，我的研究和资料依然被很好的保护着，但在上方，在那片自然产生的风暴当中，他所居住的冰之囚牢的痕迹依然存在，出没于它的诞生之地。",
            // 沉沦海
            "它被保存了几千年，是在史前海洋中寻求庇护的生物的天堂。它们没有受到进化的影响，除了适应缺氧的水域和暗淡的水晶外，它们依然在这片海域中繁衍生息。然而，仍然让我无法理解的一个谜团是，有些生物已经变得到底有多大。洞穴里明显缺乏营养和氧气，然而……",
            "这些洞穴中的海洋生物确实有眼睛，尽管它们几乎失去了原有的功能，由于缺乏使用而变得迟钝，在进行观察时会呈乳白色。在它们坚硬而多节的皮肤上，水晶无处不在且大量生长，为生物提供保护。也许这是他们适应这里的生活时的另一种方式。最惊人的奇迹是在他们的身体里。在解剖的标本中，我注意到这些矿物甚至被埋藏在它们的消化系统中。也许这些水晶会通过某种化学过程，将营养物质传递给它们那行动迟缓的宿主。真是一种奇特却无一害的互动。",
            "其中有一个标本有着异常巨大的体型，和一个无法理解且令人印象深刻的通灵能力。最令人好奇的是它和它那些体型更小的近亲之间的紧密联系。在没有任何明显的交流的情况下，当它受到威胁时，其它的软体动物会集体向攻击者发起攻击。也许这就是潜藏于沉沦之海的进化链中午的，一个更高级生命形式的最初迹象吗？又或者只是一种，会让它们在这些平静的洞穴之外的任何地区导致自身毁灭的，一种自我牺牲的侥幸呢？"
        };
        public static void Load()
        {
            logHooks = new List<Hook>();
            logHooks.Add(new Hook(typeof(DraedonLogHellGUI).GetMethod("GetTextByPage"), HellLog));
            logHooks.Add(new Hook(typeof(DraedonLogJungleGUI).GetMethod("GetTextByPage"), JungleLog));
            logHooks.Add(new Hook(typeof(DraedonLogPlanetoidGUI).GetMethod("GetTextByPage"), PlanetoidLog));
            logHooks.Add(new Hook(typeof(DraedonLogSnowBiomeGUI).GetMethod("GetTextByPage"), SnowBiomeLog));
            logHooks.Add(new Hook(typeof(DraedonLogSunkenSeaGUI).GetMethod("GetTextByPage"), SunkenSeaLog));

            foreach (Hook hook in logHooks)
            {
                if (hook is not null)
                    hook.Apply();
            }
        }
        public static void Unload()
        {
            foreach (Hook hook in logHooks)
            {
                if (hook is not null)
                    hook.Dispose();
            }
            logHooks = null;
        }
        private static string HellLog(DraedonLogHellGUI orig) => logContent[orig.Page];
        private static string JungleLog(DraedonLogJungleGUI orig) => logContent[orig.Page + 3];
        private static string PlanetoidLog(DraedonLogPlanetoidGUI orig) => logContent[orig.Page + 6];
        private static string SnowBiomeLog(DraedonLogSnowBiomeGUI orig) => logContent[orig.Page + 9];
        private static string SunkenSeaLog(DraedonLogSunkenSeaGUI orig) => logContent[orig.Page + 12];
    }
}
