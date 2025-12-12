using System.Globalization;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace TradeScope.Localization
{
    public class SimpleTranslationService : ITranslationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        // Dicionário: chave lógica -> (culture -> texto)
        private readonly Dictionary<string, Dictionary<string, string>> _translations =
            new(StringComparer.OrdinalIgnoreCase)
            {
                // =====================
                // MENU / LAYOUT
                // =====================
                ["TradeMonitoring"] = new()
                {
                    ["en"] = "Trade monitoring",
                    ["pt"] = "Monitoramento de Trade",
                    ["es"] = "Monitoreo de trading",
                    ["zh"] = "交易监控",
                    ["hi"] = "ट्रेड मॉनिटरिंग",
                    ["ar"] = "مراقبة التداول",
                    ["ru"] = "Мониторинг торговли"
                },
                ["Dashboard"] = new()
                {
                    ["en"] = "Dashboard",
                    ["pt"] = "Painel",
                    ["es"] = "Panel",
                    ["zh"] = "控制面板",
                    ["hi"] = "डैशबोर्ड",
                    ["ar"] = "لوحة التحكم",
                    ["ru"] = "Панель"
                },
                ["TradeJournal"] = new()
                {
                    ["en"] = "Trade journal",
                    ["pt"] = "Diário de Operações",
                    ["es"] = "Diario de operaciones",
                    ["zh"] = "交易日志",
                    ["hi"] = "ट्रेड जर्नल",
                    ["ar"] = "سجل التداول",
                    ["ru"] = "Журнал сделок"
                },
                ["RiskAndGrowth"] = new()
                {
                    ["en"] = "Risk & Growth",
                    ["pt"] = "Risco & Crescimento",
                    ["es"] = "Riesgo y crecimiento",
                    ["zh"] = "风险与增长",
                    ["hi"] = "जोखिम और वृद्धि",
                    ["ar"] = "المخاطر والنمو",
                    ["ru"] = "Риски и рост"
                },
                ["AssetAnalytics"] = new()
                {
                    ["en"] = "Asset analytics",
                    ["pt"] = "Análise por Ativo",
                    ["es"] = "Análisis por activo",
                    ["zh"] = "资产分析",
                    ["hi"] = "परिसंपत्ति विश्लेषण",
                    ["ar"] = "تحليل الأصول",
                    ["ru"] = "Аналитика активов"
                },
                ["Settings"] = new()
                {
                    ["en"] = "Settings",
                    ["pt"] = "Configurações",
                    ["es"] = "Configuración",
                    ["zh"] = "设置",
                    ["hi"] = "सेटिंग्स",
                    ["ar"] = "الإعدادات",
                    ["ru"] = "Настройки"
                },
                ["Mode"] = new()
                {
                    ["en"] = "Mode",
                    ["pt"] = "Modo",
                    ["es"] = "Modo",
                    ["zh"] = "模式",
                    ["hi"] = "मोड",
                    ["ar"] = "الوضع",
                    ["ru"] = "Режим"
                },

                ["GlobalSubtitle"] = new()
                {
                    ["en"] = "Clarity in every trade. Consistency in every result.",
                    ["pt"] = "Clareza nas operações. Consistência nos resultados.",
                    ["es"] = "Claridad en cada operación. Consistencia en cada resultado.",
                    ["zh"] = "每笔交易清晰可见，每个结果稳定可靠。",
                    ["hi"] = "हर ट्रेड में स्पष्टता, हर परिणाम में निरंतरता।",
                    ["ar"] = "وضوح في كل صفقة، ثبات في كل نتيجة.",
                    ["ru"] = "Четкость в каждой сделке. Стабильность в каждом результате."
                },

                // =====================
                // DASHBOARD / KPI
                // =====================
                ["DailyResult"] = new()
                {
                    ["en"] = "Daily result",
                    ["pt"] = "Resultado do dia",
                    ["es"] = "Resultado del día",
                    ["zh"] = "今日结果",
                    ["hi"] = "दैनिक परिणाम",
                    ["ar"] = "نتيجة اليوم",
                    ["ru"] = "Результат дня"
                },
                ["Live"] = new()
                {
                    ["en"] = "Live",
                    ["pt"] = "Ao vivo",
                    ["es"] = "En vivo",
                    ["zh"] = "实时",
                    ["hi"] = "लाइव",
                    ["ar"] = "مباشر",
                    ["ru"] = "В реальном времени"
                },
                ["OverCapital"] = new()
                {
                    ["en"] = "over capital",
                    ["pt"] = "sobre o capital",
                    ["es"] = "sobre el capital",
                    ["zh"] = "占总资金",
                    ["hi"] = "पूंजी पर",
                    ["ar"] = "على رأس المال",
                    ["ru"] = "от капитала"
                },
                ["DailyTarget"] = new()
                {
                    ["en"] = "Daily target",
                    ["pt"] = "Meta diária",
                    ["es"] = "Meta diaria",
                    ["zh"] = "每日目标",
                    ["hi"] = "दैनिक लक्ष्य",
                    ["ar"] = "الهدف اليومي",
                    ["ru"] = "Дневная цель"
                },
                ["CapitalCurve"] = new()
                {
                    ["en"] = "Capital curve",
                    ["pt"] = "Curva de capital",
                    ["es"] = "Curva de capital",
                    ["zh"] = "资金曲线",
                    ["hi"] = "पूंजी वक्र",
                    ["ar"] = "منحنى رأس المال",
                    ["ru"] = "Кривая капитала"
                },
                ["PerformanceByAsset"] = new()
                {
                    ["en"] = "Performance by asset",
                    ["pt"] = "Performance por ativo",
                    ["es"] = "Rendimiento por activo",
                    ["zh"] = "按资产表现",
                    ["hi"] = "परिसंपत्ति के अनुसार प्रदर्शन",
                    ["ar"] = "الأداء حسب الأصل",
                    ["ru"] = "Доходность по активам"
                },
                ["LastTrades"] = new()
                {
                    ["en"] = "Latest trades",
                    ["pt"] = "Últimas operações",
                    ["es"] = "Últimas operaciones",
                    ["zh"] = "最近交易",
                    ["hi"] = "हाल के ट्रेड",
                    ["ar"] = "آخر العمليات",
                    ["ru"] = "Последние сделки"
                },
                ["Phase"] = new()
                {
                    ["en"] = "Phase",
                    ["pt"] = "Fase",
                    ["es"] = "Fase",
                    ["zh"] = "阶段",
                    ["hi"] = "चरण",
                    ["ar"] = "المرحلة",
                    ["ru"] = "Этап"
                },
                ["Result"] = new()
                {
                    ["en"] = "Result",
                    ["pt"] = "Resultado",
                    ["es"] = "Resultado",
                    ["zh"] = "结果",
                    ["hi"] = "परिणाम",
                    ["ar"] = "النتيجة",
                    ["ru"] = "Результат"
                },
                ["Points"] = new()
                {
                    ["en"] = "Points",
                    ["pt"] = "Pontos",
                    ["es"] = "Puntos",
                    ["zh"] = "点数",
                    ["hi"] = "अंक",
                    ["ar"] = "النقاط",
                    ["ru"] = "Очки"
                },
                ["Pattern10X"] = new()
                {
                    ["en"] = "10x pattern",
                    ["pt"] = "Padrão 10x",
                    ["es"] = "Patrón 10x",
                    ["zh"] = "10x模式",
                    ["hi"] = "10x पैटर्न",
                    ["ar"] = "نمط 10x",
                    ["ru"] = "Модель 10x"
                },
                ["Win"] = new()
                {
                    ["en"] = "Win",
                    ["pt"] = "Ganho",
                    ["es"] = "Ganancia",
                    ["zh"] = "盈利",
                    ["hi"] = "लाभ",
                    ["ar"] = "ربح",
                    ["ru"] = "Выигрыш"
                },
                ["Loss"] = new()
                {
                    ["en"] = "Loss",
                    ["pt"] = "Perda",
                    ["es"] = "Pérdida",
                    ["zh"] = "亏损",
                    ["hi"] = "हानि",
                    ["ar"] = "خسارة",
                    ["ru"] = "Потеря"
                },
                ["MetaWIN"] = new()
                {
                    ["en"] = "Target: > 400 pts",
                    ["pt"] = "Meta: > 400 pts",
                    ["es"] = "Meta: > 400 pts",
                    ["zh"] = "目标: > 400 点",
                    ["hi"] = "लक्ष्य: > 400 अंक",
                    ["ar"] = "الهدف: > 400 نقطة",
                    ["ru"] = "Цель: > 400 пунктов"
                },
                ["MetaWDO"] = new()
                {
                    ["en"] = "Target: > 14 pts",
                    ["pt"] = "Meta: > 14 pts",
                    ["es"] = "Meta: > 14 pts",
                    ["zh"] = "目标: > 14 点",
                    ["hi"] = "लक्ष्य: > 14 अंक",
                    ["ar"] = "الهدف: > 14 نقطة",
                    ["ru"] = "Цель: > 14 пунктов"
                },
                ["MetaNAS"] = new()
                {
                    ["en"] = "Target: > 70 pts",
                    ["pt"] = "Meta: > 70 pts",
                    ["es"] = "Meta: > 70 pts",
                    ["zh"] = "目标: > 70 点",
                    ["hi"] = "लक्ष्य: > 70 अंक",
                    ["ar"] = "الهدف: > 70 نقطة",
                    ["ru"] = "Цель: > 70 пунктов"
                },
                ["FilterOperationsTitle"] = new()
                {
                    ["en"] = "Operations filter",
                    ["pt"] = "Filtro de operações",
                    ["es"] = "Filtro de operaciones",
                    ["zh"] = "交易筛选",
                    ["hi"] = "ट्रेड फ़िल्टर",
                    ["ar"] = "تصفية العمليات",
                    ["ru"] = "Фильтр сделок"
                },
                ["FilterFrom"] = new()
                {
                    ["en"] = "From",
                    ["pt"] = "De",
                    ["es"] = "Desde",
                    ["zh"] = "起始日期",
                    ["hi"] = "से",
                    ["ar"] = "من",
                    ["ru"] = "С"
                },
                ["FilterTo"] = new()
                {
                    ["en"] = "To",
                    ["pt"] = "Até",
                    ["es"] = "Hasta",
                    ["zh"] = "结束日期",
                    ["hi"] = "तक",
                    ["ar"] = "إلى",
                    ["ru"] = "По"
                },
                ["FilterResult"] = new()
                {
                    ["en"] = "Result",
                    ["pt"] = "Resultado",
                    ["es"] = "Resultado",
                    ["zh"] = "结果",
                    ["hi"] = "परिणाम",
                    ["ar"] = "النتيجة",
                    ["ru"] = "Результат"
                },
                ["FilterAll"] = new()
                {
                    ["en"] = "All",
                    ["pt"] = "Todos",
                    ["es"] = "Todos",
                    ["zh"] = "全部",
                    ["hi"] = "सभी",
                    ["ar"] = "الكل",
                    ["ru"] = "Все"
                },
                ["ApplyFilter"] = new()
                {
                    ["en"] = "Apply filter",
                    ["pt"] = "Aplicar filtro",
                    ["es"] = "Aplicar filtro",
                    ["zh"] = "应用筛选",
                    ["hi"] = "फ़िल्टर लागू करें",
                    ["ar"] = "تطبيق التصفية",
                    ["ru"] = "Применить фильтр"
                },
                ["NewOperationFuture"] = new()
                {
                    ["en"] = "New operation (future)",
                    ["pt"] = "Nova operação (futuro)",
                    ["es"] = "Nueva operación (futuro)",
                    ["zh"] = "新交易（预留）",
                    ["hi"] = "नई ट्रेड (भविष्य)",
                    ["ar"] = "عملية جديدة (لاحقًا)",
                    ["ru"] = "Новая сделка (позже)"
                },
                ["RegisteredOperations"] = new()
                {
                    ["en"] = "Registered operations",
                    ["pt"] = "Operações registradas",
                    ["es"] = "Operaciones registradas",
                    ["zh"] = "已记录的交易",
                    ["hi"] = "पंजीकृत ट्रेड",
                    ["ar"] = "العمليات المسجلة",
                    ["ru"] = "Зарегистрированные сделки"
                },
                ["OperationsCountMock"] = new()
                {
                    ["en"] = "{0} mocked operation(s)",
                    ["pt"] = "{0} operação(ões) mockadas",
                    ["es"] = "{0} operación(es) simulada(s)",
                    ["zh"] = "模拟交易 {0} 条",
                    ["hi"] = "{0} नकली ट्रेड",
                    ["ar"] = "{0} عملية تجريبية",
                    ["ru"] = "{0} тестовых сделок"
                },
                ["RiskCurrentCapital"] = new()
                {
                    ["en"] = "Current capital",
                    ["pt"] = "Capital atual",
                    ["es"] = "Capital actual",
                    ["zh"] = "当前资金",
                    ["hi"] = "वर्तमान पूंजी",
                    ["ar"] = "رأس المال الحالي",
                    ["ru"] = "Текущий капитал"
                },
                ["RiskPerTrade"] = new()
                {
                    ["en"] = "Risk per trade",
                    ["pt"] = "Risco por trade",
                    ["es"] = "Riesgo por operación",
                    ["zh"] = "每笔交易风险",
                    ["hi"] = "प्रति ट्रेड जोखिम",
                    ["ar"] = "المخاطر في كل صفقة",
                    ["ru"] = "Риск на сделку"
                },
                ["MaxDailyRisk"] = new()
                {
                    ["en"] = "Maximum daily risk",
                    ["pt"] = "Risco diário máximo",
                    ["es"] = "Riesgo diario máximo",
                    ["zh"] = "每日最大风险",
                    ["hi"] = "अधिकतम दैनिक जोखिम",
                    ["ar"] = "أقصى مخاطرة يومية",
                    ["ru"] = "Максимальный дневной риск"
                },
                ["ExpectedGrowth"] = new()
                {
                    ["en"] = "Expected growth",
                    ["pt"] = "Crescimento esperado",
                    ["es"] = "Crecimiento esperado",
                    ["zh"] = "预期增长",
                    ["hi"] = "अपेक्षित वृद्धि",
                    ["ar"] = "النمو المتوقع",
                    ["ru"] = "Ожидаемый рост"
                },
                ["GrowthSimulator"] = new()
                {
                    ["en"] = "Growth simulator",
                    ["pt"] = "Simulador de crescimento",
                    ["es"] = "Simulador de crecimiento",
                    ["zh"] = "增长模拟器",
                    ["hi"] = "वृद्धि सिम्युलेटर",
                    ["ar"] = "محاكي النمو",
                    ["ru"] = "Симулятор роста"
                },
                ["RiskSummaryRules"] = new()
                {
                    ["en"] = "Risk rules summary",
                    ["pt"] = "Resumo de regras de risco",
                    ["es"] = "Resumen de reglas de riesgo",
                    ["zh"] = "风险规则摘要",
                    ["hi"] = "जोखिम नियम सारांश",
                    ["ar"] = "ملخص قواعد المخاطرة",
                    ["ru"] = "Сводка правил риска"
                },
                ["RiskRuleMaxTrades"] = new()
                {
                    ["en"] = "Max. {0} trades per day (exposure limit).",
                    ["pt"] = "Máx. {0} trades por dia (limite de exposição).",
                    ["es"] = "Máx. {0} operaciones por día (límite de exposición).",
                    ["zh"] = "每天最多 {0} 笔交易（风险敞口上限）。",
                    ["hi"] = "प्रति दिन अधिकतम {0} ट्रेड (एक्सपोज़र सीमा)।",
                    ["ar"] = "بحد أقصى {0} صفقات في اليوم (حد الانكشاف).",
                    ["ru"] = "Максимум {0} сделок в день (лимит экспозиции)."
                },
                ["RiskRulePhaseAdapt"] = new()
                {
                    ["en"] = "Automatic adjustment by phase (aggressive → moderate → conservative).",
                    ["pt"] = "Adaptação automática por fase (agressivo → moderado → conservador).",
                    ["es"] = "Ajuste automático por fase (agresiva → moderada → conservadora).",
                    ["zh"] = "按阶段自动调整（激进 → 中等 → 保守）。",
                    ["hi"] = "फेज़ के अनुसार स्वचालित समायोजन (आक्रामक → मध्यम → रूढ़िवादी)।",
                    ["ar"] = "تعديل تلقائي حسب المرحلة (هجومية → متوسطة → محافظة).",
                    ["ru"] = "Автоматическая адаптация по фазам (агрессивная → умеренная → консервативная)."
                },
                ["Overview"] = new()
                {
                    ["en"] = "Overview",
                    ["pt"] = "Visão geral",
                    ["es"] = "Visión general",
                    ["zh"] = "概览",
                    ["hi"] = "सारांश",
                    ["ar"] = "نظرة عامة",
                    ["ru"] = "Общий обзор"
                },
                ["BestAsset"] = new()
                {
                    ["en"] = "Best performing asset:",
                    ["pt"] = "Ativo com melhor performance:",
                    ["es"] = "Activo con mejor rendimiento:",
                    ["zh"] = "表现最佳的品种：",
                    ["hi"] = "सबसे अच्छा प्रदर्शन करने वाला एसेट:",
                    ["ar"] = "أفضل أصل أداءً:",
                    ["ru"] = "Лучший актив по доходности:"
                },
                ["WorstAsset"] = new()
                {
                    ["en"] = "Most sensitive / weak asset:",
                    ["pt"] = "Ativo mais sensível / fraco:",
                    ["es"] = "Activo más sensible / débil:",
                    ["zh"] = "最敏感/较弱的品种：",
                    ["hi"] = "सबसे संवेदनशील / कमजोर एसेट:",
                    ["ar"] = "الأصل الأكثر حساسية / ضعفًا:",
                    ["ru"] = "Самый чувствительный / слабый актив:"
                },
                ["DistributionPlaceholderTitle"] = new()
                {
                    ["en"] = "Results distribution (placeholder)",
                    ["pt"] = "Distribuição de resultados (placeholder)",
                    ["es"] = "Distribución de resultados (placeholder)",
                    ["zh"] = "结果分布（占位）",
                    ["hi"] = "परिणाम वितरण (placeholder)",
                    ["ar"] = "توزيع النتائج (placeholder)",
                    ["ru"] = "Распределение результатов (заглушка)"
                },
                ["DistributionPlaceholderText"] = new()
                {
                    ["en"] = "Future: bar chart / heatmap by asset and time.",
                    ["pt"] = "Futuro: gráfico de barras / heatmap por ativo e horário.",
                    ["es"] = "Futuro: gráfico de barras / mapa de calor por activo y horario.",
                    ["zh"] = "未来：按品种和时间显示柱状图/热力图。",
                    ["hi"] = "भविष्य: एसेट और समय के अनुसार बार/हीटमैप।",
                    ["ar"] = "لاحقًا: مخطط أعمدة / خريطة حرارية حسب الأصل والوقت.",
                    ["ru"] = "В будущем: столбчатая диаграмма / тепловая карта по активам и времени."
                },
                ["MainParameters"] = new()
                {
                    ["en"] = "Main parameters",
                    ["pt"] = "Parâmetros principais",
                    ["es"] = "Parámetros principales",
                    ["zh"] = "主要参数",
                    ["hi"] = "मुख्य पैरामीटर",
                    ["ar"] = "المعلمات الرئيسية",
                    ["ru"] = "Основные параметры"
                },
                ["MockNotice"] = new()
                {
                    ["en"] = "Initial mock for layout · will save in the future",
                    ["pt"] = "Mock inicial para layout · salvará no futuro",
                    ["es"] = "Mock inicial para diseño · se guardará en el futuro",
                    ["zh"] = "布局初始模拟 · 未来将支持保存",
                    ["hi"] = "प्रारंभिक लेआउट मॉक · भविष्य में सेव होगा",
                    ["ar"] = "نموذج أولي للتصميم · سيتم الحفظ لاحقًا",
                    ["ru"] = "Начальный макет · сохранение будет реализовано позже"
                },
                ["CapitalAndRisk"] = new()
                {
                    ["en"] = "Capital & Risk",
                    ["pt"] = "Capital & Risco",
                    ["es"] = "Capital y riesgo",
                    ["zh"] = "资金与风险",
                    ["hi"] = "पूंजी और जोखिम",
                    ["ar"] = "رأس المال والمخاطر",
                    ["ru"] = "Капитал и риск"
                },
                ["InitialCapital"] = new()
                {
                    ["en"] = "Initial capital",
                    ["pt"] = "Capital inicial",
                    ["es"] = "Capital inicial",
                    ["zh"] = "初始资金",
                    ["hi"] = "प्रारंभिक पूंजी",
                    ["ar"] = "رأس المال الابتدائي",
                    ["ru"] = "Начальный капитал"
                },
                ["RiskPerTradePercentLabel"] = new()
                {
                    ["en"] = "Risk per trade (%)",
                    ["pt"] = "Risco por trade (%)",
                    ["es"] = "Riesgo por operación (%)",
                    ["zh"] = "每笔交易风险 (%)",
                    ["hi"] = "प्रति ट्रेड जोखिम (%)",
                    ["ar"] = "المخاطر لكل صفقة (%)",
                    ["ru"] = "Риск на сделку (%)"
                },
                ["TradesPerPhase"] = new()
                {
                    ["en"] = "Trades per phase",
                    ["pt"] = "Operações por fase",
                    ["es"] = "Operaciones por fase",
                    ["zh"] = "每阶段交易次数",
                    ["hi"] = "फेज़ के अनुसार ट्रेड",
                    ["ar"] = "الصفقات لكل مرحلة",
                    ["ru"] = "Сделки по фазам"
                },
                ["Phase1Aggressive"] = new()
                {
                    ["en"] = "Phase 1 · aggressive (trades/day)",
                    ["pt"] = "Fase 1 · agressiva (ops/dia)",
                    ["es"] = "Fase 1 · agresiva (ops/día)",
                    ["zh"] = "阶段 1 · 激进（笔/天）",
                    ["hi"] = "फेज़ 1 · आक्रामक (ट्रेड/दिन)",
                    ["ar"] = "المرحلة 1 · هجومية (صفقات/يوم)",
                    ["ru"] = "Фаза 1 · агрессивная (сделок/день)"
                },
                ["Phase2Moderate"] = new()
                {
                    ["en"] = "Phase 2 · moderate (trades/day)",
                    ["pt"] = "Fase 2 · moderada (ops/dia)",
                    ["es"] = "Fase 2 · moderada (ops/día)",
                    ["zh"] = "阶段 2 · 中等（笔/天）",
                    ["hi"] = "फेज़ 2 · मध्यम (ट्रेड/दिन)",
                    ["ar"] = "المرحلة 2 · متوسطة (صفقات/يوم)",
                    ["ru"] = "Фаза 2 · умеренная (сделок/день)"
                },
                ["Phase3Conservative"] = new()
                {
                    ["en"] = "Phase 3 · conservative (trades/day)",
                    ["pt"] = "Fase 3 · conservadora (ops/dia)",
                    ["es"] = "Fase 3 · conservadora (ops/día)",
                    ["zh"] = "阶段 3 · 保守（笔/天）",
                    ["hi"] = "फेज़ 3 · रूढ़िवादी (ट्रेड/दिन)",
                    ["ar"] = "المرحلة 3 · محافظة (صفقات/يوم)",
                    ["ru"] = "Фаза 3 · консервативная (сделок/день)"
                },
                ["PointsTargets"] = new()
                {
                    ["en"] = "Points targets",
                    ["pt"] = "Metas de pontos",
                    ["es"] = "Metas de puntos",
                    ["zh"] = "点数目标",
                    ["hi"] = "पॉइंट लक्ष्य",
                    ["ar"] = "أهداف النقاط",
                    ["ru"] = "Цели по пунктам"
                },
                ["Withdrawals"] = new()
                {
                    ["en"] = "Withdrawals",
                    ["pt"] = "Retiradas",
                    ["es"] = "Retiros",
                    ["zh"] = "提款",
                    ["hi"] = "निकासी",
                    ["ar"] = "السحوبات",
                    ["ru"] = "Вывод средств"
                },
                ["SaveFuture"] = new()
                {
                    ["en"] = "Save (future)",
                    ["pt"] = "Salvar (futuro)",
                    ["es"] = "Guardar (futuro)",
                    ["zh"] = "保存（预留）",
                    ["hi"] = "सेव (भविष्य)",
                    ["ar"] = "حفظ (لاحقًا)",
                    ["ru"] = "Сохранить (позже)"
                },
                ["ConcludedTrades"] = new()
                {
                    ["en"] = "Save (future)",
                    ["pt"] = "Salvar (futuro)",
                    ["es"] = "Guardar (futuro)",
                    ["zh"] = "保存（预留）",
                    ["hi"] = "सेव (भविष्य)",
                    ["ar"] = "حفظ (لاحقًا)",
                    ["ru"] = "Сохранить (позже)"
                },
                ["CompletedTrades"] = new()
                {
                    ["en"] = "completed trades",
                    ["pt"] = "trades concluídos",
                    ["es"] = "trades completados",
                    ["zh"] = "已完成交易",
                    ["hi"] = "समाप्त ट्रेड",
                    ["ar"] = "الصفقات المنفذة",
                    ["ru"] = "завершённые сделки"
                },
                ["GainsPlural"] = new()
                {
                    ["en"] = "gains",
                    ["pt"] = "ganhos",
                    ["es"] = "ganancias",
                    ["zh"] = "盈利",
                    ["hi"] = "लाभ",
                    ["ar"] = "أرباح",
                    ["ru"] = "прибыли"
                },
                ["LossesPlural"] = new()
                {
                    ["en"] = "losses",
                    ["pt"] = "perdas",
                    ["es"] = "pérdidas",
                    ["zh"] = "亏损",
                    ["hi"] = "हानियाँ",
                    ["ar"] = "خسائر",
                    ["ru"] = "убытки"
                },
                ["PerTrade"] = new()
                {
                    ["en"] = "per trade",
                    ["pt"] = "por trade",
                    ["es"] = "por trade",
                    ["zh"] = "每笔交易",
                    ["hi"] = "प्रति ट्रेड",
                    ["ar"] = "لكل صفقة",
                    ["ru"] = "на сделку"
                },
                ["GoalLabel"] = new()
                {
                    ["en"] = "Goal:",
                    ["pt"] = "Objetivo:",
                    ["es"] = "Objetivo:",
                    ["zh"] = "目标：",
                    ["hi"] = "लक्ष्य:",
                    ["ar"] = "الهدف:",
                    ["ru"] = "Цель:"
                },
                ["ExponentialGrowth"] = new()
                {
                    ["en"] = "exponential growth",
                    ["pt"] = "crescimento exponencial",
                    ["es"] = "crecimiento exponencial",
                    ["zh"] = "指数型增长",
                    ["hi"] = "घातीय वृद्धि",
                    ["ar"] = "نمو أُسِّي",
                    ["ru"] = "экспоненциальный рост"
                },
                ["TabWeek"] = new()
                {
                    ["en"] = "Week",
                    ["pt"] = "Semana",
                    ["es"] = "Semana",
                    ["zh"] = "一周",
                    ["hi"] = "सप्ताह",
                    ["ar"] = "أسبوع",
                    ["ru"] = "Неделя"
                },
                ["TabMonth"] = new()
                {
                    ["en"] = "Month",
                    ["pt"] = "Mês",
                    ["es"] = "Mes",
                    ["zh"] = "月",
                    ["hi"] = "माह",
                    ["ar"] = "شهر",
                    ["ru"] = "Месяц"
                },
                ["Tab90Days"] = new()
                {
                    ["en"] = "90 days",
                    ["pt"] = "90 dias",
                    ["es"] = "90 días",
                    ["zh"] = "90 天",
                    ["hi"] = "90 दिन",
                    ["ar"] = "90 يوماً",
                    ["ru"] = "90 дней"
                },
                ["AssetLabel"] = new()
                {
                    ["en"] = "Asset",
                    ["pt"] = "Ativo",
                    ["es"] = "Activo",
                    ["zh"] = "资产",
                    ["hi"] = "एसेट",
                    ["ar"] = "الأصل",
                    ["ru"] = "Актив"
                },
                ["TargetLabel"] = new()
                {
                    ["en"] = "Target",
                    ["pt"] = "Meta",
                    ["es"] = "Meta",
                    ["zh"] = "目标",
                    ["hi"] = "लक्ष्य",
                    ["ar"] = "الهدف",
                    ["ru"] = "Цель"
                },
                ["PointsAccumulated"] = new()
                {
                    ["en"] = "Accumulated points",
                    ["pt"] = "Pontos acumulados",
                    ["es"] = "Puntos acumulados",
                    ["zh"] = "累计点数",
                    ["hi"] = "संचित अंक",
                    ["ar"] = "النقاط المتراكمة",
                    ["ru"] = "накопленные пункты"
                },
                ["WinRateLabel"] = new()
                {
                    ["en"] = "WinRate",
                    ["pt"] = "WinRate",
                    ["es"] = "WinRate",
                    ["zh"] = "胜率 WinRate",
                    ["hi"] = "WinRate",
                    ["ar"] = "WinRate",
                    ["ru"] = "WinRate"
                },
                ["ResultsDistribution"] = new()
                {
                    ["en"] = "Results distribution",
                    ["pt"] = "Distribuição de resultados",
                    ["es"] = "Distribución de resultados",
                    ["zh"] = "结果分布",
                    ["hi"] = "परिणाम वितरण",
                    ["ar"] = "توزيع النتائج",
                    ["ru"] = "Распределение результатов"
                },
                ["FuturePrefix"] = new()
                {
                    ["en"] = "Future:",
                    ["pt"] = "Futuro:",
                    ["es"] = "Futuro:",
                    ["zh"] = "未来：",
                    ["hi"] = "भविष्य:",
                    ["ar"] = "لاحقاً:",
                    ["ru"] = "В будущем:"
                },
                ["BarChart"] = new()
                {
                    ["en"] = "bar chart",
                    ["pt"] = "gráfico de barras",
                    ["es"] = "gráfico de barras",
                    ["zh"] = "柱状图",
                    ["hi"] = "बार चार्ट",
                    ["ar"] = "مخطط أعمدة",
                    ["ru"] = "гистограмма"
                },
                ["HeatmapByAssetAndTime"] = new()
                {
                    ["en"] = "heatmap by asset and time",
                    ["pt"] = "heatmap por ativo e horário",
                    ["es"] = "heatmap por activo y horario",
                    ["zh"] = "按资产和时间的热力图",
                    ["hi"] = "एसेट और समय के अनुसार हीटमैप",
                    ["ar"] = "خريطة حرارية حسب الأصل والوقت",
                    ["ru"] = "тепловая карта по активам и времени"
                },
                ["NewOperation"] = new()
                {
                    ["en"] = "New operation",
                    ["pt"] = "Nova operação",
                    ["es"] = "Nueva operación",
                    ["zh"] = "新交易",
                    ["hi"] = "नई ट्रेड",
                    ["ar"] = "عملية جديدة",
                    ["ru"] = "Новая сделка"
                },
                ["ContractsLabel"] = new()
                {
                    ["en"] = "Contracts",
                    ["pt"] = "Contratos",
                    ["es"] = "Contratos",
                    ["zh"] = "合约",
                    ["hi"] = "कॉन्ट्रैक्ट्स",
                    ["ar"] = "عقود",
                    ["ru"] = "Контракты"
                },
                ["PerOperation"] = new()
                {
                    ["en"] = "per operation",
                    ["pt"] = "por operação",
                    ["es"] = "por operación",
                    ["zh"] = "每笔操作",
                    ["hi"] = "प्रति ऑपरेशन",
                    ["ar"] = "لكل عملية",
                    ["ru"] = "за операцию"
                },
                ["TradesLabel"] = new()
                {
                    ["en"] = "Trades",
                    ["pt"] = "Trades",
                    ["es"] = "Trades",
                    ["zh"] = "交易",
                    ["hi"] = "ट्रेड्स",
                    ["ar"] = "تداولات",
                    ["ru"] = "Сделки"
                },
                ["DayLabel"] = new()
                {
                    ["en"] = "Day",
                    ["pt"] = "Dia",
                    ["es"] = "Día",
                    ["zh"] = "日",
                    ["hi"] = "दिन",
                    ["ar"] = "اليوم",
                    ["ru"] = "День"
                },
                ["MaxPrefix"] = new()
                {
                    ["en"] = "Max.",
                    ["pt"] = "Máx.",
                    ["es"] = "Máx.",
                    ["zh"] = "最大",
                    ["hi"] = "अधिकतम",
                    ["ar"] = "الحد الأقصى",
                    ["ru"] = "Макс."
                },
                ["TradesPerDayExposure"] = new()
                {
                    ["en"] = "trades per day (exposure limit)",
                    ["pt"] = "trades por dia (limite de exposição)",
                    ["es"] = "trades por día (límite de exposición)",
                    ["zh"] = "每日交易笔数（风险敞口上限）",
                    ["hi"] = "ट्रेड्स प्रति दिन (एक्सपोज़र सीमा)",
                    ["ar"] = "صفقات في اليوم (حد الانكشاف)",
                    ["ru"] = "сделок в день (лимит экспозиции)"
                },
                ["OnAverage"] = new()
                {
                    ["en"] = "on average",
                    ["pt"] = "em média",
                    ["es"] = "en promedio",
                    ["zh"] = "平均",
                    ["hi"] = "औसतन",
                    ["ar"] = "في المتوسط",
                    ["ru"] = "в среднем"
                },
                ["AggressiveLabel"] = new()
                {
                    ["en"] = "Aggressive",
                    ["pt"] = "Agressivo",
                    ["es"] = "Agresivo",
                    ["zh"] = "激进",
                    ["hi"] = "आक्रामक",
                    ["ar"] = "هجومي",
                    ["ru"] = "Агрессивный"
                },
                ["ModerateLabel"] = new()
                {
                    ["en"] = "Moderate",
                    ["pt"] = "Moderado",
                    ["es"] = "Moderado",
                    ["zh"] = "中等",
                    ["hi"] = "मध्यम",
                    ["ar"] = "متوسط",
                    ["ru"] = "Умеренный"
                },
                ["ConservativeLabel"] = new()
                {
                    ["en"] = "Conservative",
                    ["pt"] = "Conservador",
                    ["es"] = "Conservador",
                    ["zh"] = "保守",
                    ["hi"] = "रूढ़िवादी",
                    ["ar"] = "محافظ",
                    ["ru"] = "Консервативный"
                },
                ["CapitalLabel"] = new()
                {
                    ["en"] = "Capital",
                    ["pt"] = "Capital",
                    ["es"] = "Capital",
                    ["zh"] = "资金",
                    ["hi"] = "पूंजी",
                    ["ar"] = "رأس المال",
                    ["ru"] = "Капитал"
                },
                ["RiskLabel"] = new()
                {
                    ["en"] = "Risk",
                    ["pt"] = "Risco",
                    ["es"] = "Riesgo",
                    ["zh"] = "风险",
                    ["hi"] = "जोखिम",
                    ["ar"] = "المخاطر",
                    ["ru"] = "Риск"
                },
                ["InitialLabel"] = new()
                {
                    ["en"] = "Initial",
                    ["pt"] = "Inicial",
                    ["es"] = "Inicial",
                    ["zh"] = "初始",
                    ["hi"] = "प्रारंभिक",
                    ["ar"] = "أولي",
                    ["ru"] = "Начальный"
                },

                ["Phase1Label"] = new()
                {
                    ["en"] = "Phase 1",
                    ["pt"] = "Fase 1",
                    ["es"] = "Fase 1",
                    ["zh"] = "阶段 1",
                    ["hi"] = "फेज़ 1",
                    ["ar"] = "المرحلة 1",
                    ["ru"] = "Фаза 1"
                },
                ["OperationsLabel"] = new()
                {
                    ["en"] = "Operations",
                    ["pt"] = "Operações",
                    ["es"] = "Operaciones",
                    ["zh"] = "操作",
                    ["hi"] = "ऑपरेशन्स",
                    ["ar"] = "العمليات",
                    ["ru"] = "Операции"
                },
                ["Phase2Label"] = new()
                {
                    ["en"] = "Phase 2",
                    ["pt"] = "Fase 2",
                    ["es"] = "Fase 2",
                    ["zh"] = "阶段 2",
                    ["hi"] = "फेज़ 2",
                    ["ar"] = "المرحلة 2",
                    ["ru"] = "Фаза 2"
                },
                ["Phase3Label"] = new()
                {
                    ["en"] = "Phase 3",
                    ["pt"] = "Fase 3",
                    ["es"] = "Fase 3",
                    ["zh"] = "阶段 3",
                    ["hi"] = "फेज़ 3",
                    ["ar"] = "المرحلة 3",
                    ["ru"] = "Фаза 3"
                },
                ["MiniIndexLabel"] = new()
                {
                    ["en"] = "Mini Index",
                    ["pt"] = "Mini Índice",
                    ["es"] = "Mini Índice",
                    ["zh"] = "迷你指数",
                    ["hi"] = "मिनी इंडेक्स",
                    ["ar"] = "ميني مؤشر",
                    ["ru"] = "Мини-индекс"
                },
                ["DollarLabel"] = new()
                {
                    ["en"] = "Dollar",
                    ["pt"] = "Dólar",
                    ["es"] = "Dólar",
                    ["zh"] = "美元",
                    ["hi"] = "डॉलर",
                    ["ar"] = "دولار",
                    ["ru"] = "Доллар"
                },
                ["NasdaqLabel"] = new()
                {
                    ["en"] = "Nasdaq",
                    ["pt"] = "Nasdaq",
                    ["es"] = "Nasdaq",
                    ["zh"] = "纳斯达克",
                    ["hi"] = "नैस्डैक",
                    ["ar"] = "ناسداك",
                    ["ru"] = "Nasdaq"
                },
                ["MonthlyIncrement"] = new()
                {
                    ["en"] = "Monthly increment",
                    ["pt"] = "Incremento mensal",
                    ["es"] = "Incremento mensual",
                    ["zh"] = "每月增量",
                    ["hi"] = "मासिक वृद्धि",
                    ["ar"] = "الزيادة الشهرية",
                    ["ru"] = "Ежемесячное увеличение"
                },
                ["MaxWithdrawal"] = new()
                {
                    ["en"] = "Maximum withdrawal",
                    ["pt"] = "Retirada máxima",
                    ["es"] = "Retiro máximo",
                    ["zh"] = "最大提取额",
                    ["hi"] = "अधिकतम निकासी",
                    ["ar"] = "الحد الأقصى للسحب",
                    ["ru"] = "Максимальный вывод"
                },
                ["SaveLabel"] = new()
                {
                    ["en"] = "Save",
                    ["pt"] = "Salvar",
                    ["es"] = "Guardar",
                    ["zh"] = "保存",
                    ["hi"] = "सहेजें",
                    ["ar"] = "حفظ",
                    ["ru"] = "Сохранить"
                },
                ["CancelLabel"] = new()
                {
                    ["en"] = "Cancel",
                    ["pt"] = "Cancelar",
                    ["es"] = "Cancelar",
                    ["zh"] = "取消",
                    ["hi"] = "रद्द करें",
                    ["ar"] = "إلغاء",
                    ["ru"] = "Отмена"
                },
                ["BackLabel"] = new()
                {
                    ["en"] = "Back",
                    ["pt"] = "Voltar",
                    ["es"] = "Volver",
                    ["zh"] = "返回",
                    ["hi"] = "वापस",
                    ["ar"] = "رجوع",
                    ["ru"] = "Назад"
                },
                ["EditLabel"] = new()
                {
                    ["en"] = "Edit",
                    ["pt"] = "Editar",
                    ["es"] = "Editar",
                    ["zh"] = "编辑",
                    ["hi"] = "संपादित करें",
                    ["ar"] = "تعديل",
                    ["ru"] = "Редактировать"
                },
                ["DeleteLabel"] = new()
                {
                    ["en"] = "Delete",
                    ["pt"] = "Excluir",
                    ["es"] = "Eliminar",
                    ["zh"] = "删除",
                    ["hi"] = "हटाएँ",
                    ["ar"] = "حذف",
                    ["ru"] = "Удалить"
                },
                ["CopyLabel"] = new()
                {
                    ["en"] = "Copy",
                    ["pt"] = "Copiar",
                    ["es"] = "Copiar",
                    ["zh"] = "复制",
                    ["hi"] = "कॉपी करें",
                    ["ar"] = "نسخ",
                    ["ru"] = "Копировать"
                },
                ["UploadLabel"] = new()
                {
                    ["en"] = "Upload",
                    ["pt"] = "Upload",
                    ["es"] = "Upload",
                    ["zh"] = "上传",
                    ["hi"] = "अपलोड",
                    ["ar"] = "رفع",
                    ["ru"] = "Загрузить"
                },
                ["DownloadLabel"] = new()
                {
                    ["en"] = "Download",
                    ["pt"] = "Download",
                    ["es"] = "Download",
                    ["zh"] = "下载",
                    ["hi"] = "डाउनलोड",
                    ["ar"] = "تنزيل",
                    ["ru"] = "Скачать"
                },
                ["ExportLabel"] = new()
                {
                    ["en"] = "Export",
                    ["pt"] = "Exportar",
                    ["es"] = "Exportar",
                    ["zh"] = "导出",
                    ["hi"] = "एक्सपोर्ट",
                    ["ar"] = "تصدير",
                    ["ru"] = "Экспорт"
                },
                ["WithBestPerformance"] = new()
                {
                    ["en"] = "with best performance",
                    ["pt"] = "com melhor performance",
                    ["es"] = "con mejor rendimiento",
                    ["zh"] = "表现最佳",
                    ["hi"] = "सबसे बेहतर प्रदर्शन वाला",
                    ["ar"] = "ذو أفضل أداء",
                    ["ru"] = "с лучшей доходностью"
                },
                ["MoreSensitive"] = new()
                {
                    ["en"] = "more sensitive",
                    ["pt"] = "mais sensível",
                    ["es"] = "más sensible",
                    ["zh"] = "更敏感",
                    ["hi"] = "अधिक संवेदनशील",
                    ["ar"] = "الأكثر حساسية",
                    ["ru"] = "более чувствительный"
                },
                ["WeakLabel2"] = new()
                {
                    ["en"] = "weak",
                    ["pt"] = "fraco",
                    ["es"] = "débil",
                    ["zh"] = "较弱",
                    ["hi"] = "कमज़ोर",
                    ["ar"] = "ضعيف",
                    ["ru"] = "слабый"
                },
                ["Last50Trades"] = new()
                {
                    ["en"] = "Last 50 trades",
                    ["pt"] = "Últimos 50 trades",
                    ["es"] = "Últimos 50 trades",
                    ["zh"] = "最近 50 笔交易",
                    ["hi"] = "पिछले 50 ट्रेड",
                    ["ar"] = "آخر 50 صفقة",
                    ["ru"] = "Последние 50 сделок"
                },
                ["TargetWithdrawal"] = new()
                {
                    ["en"] = "Target withdrawal",
                    ["pt"] = "Retirada alvo",
                    ["es"] = "Retiro objetivo",
                    ["zh"] = "目标提取额",
                    ["hi"] = "लक्ष्य निकासी",
                    ["ar"] = "قيمة السحب المستهدفة",
                    ["ru"] = "Целевая сумма вывода"
                },
                ["DateLabel"] = new()
                {
                    ["en"] = "Date",
                    ["pt"] = "Data",
                    ["es"] = "Fecha",
                    ["zh"] = "日期",
                    ["hi"] = "तारीख",
                    ["ar"] = "التاريخ",
                    ["ru"] = "Дата"
                },
                ["FromSimple"] = new()
                {
                    ["en"] = "From",
                    ["pt"] = "De",
                    ["es"] = "Desde",
                    ["zh"] = "从",
                    ["hi"] = "से",
                    ["ar"] = "من",
                    ["ru"] = "С"
                },
                ["ToSimple"] = new()
                {
                    ["en"] = "To",
                    ["pt"] = "Até",
                    ["es"] = "Hasta",
                    ["zh"] = "到",
                    ["hi"] = "तक",
                    ["ar"] = "إلى",
                    ["ru"] = "По"
                },
                ["EvPerTradeLabel"] = new()
                {
                    ["en"] = "EV/trade:",
                    ["pt"] = "EV/trade:",
                    ["es"] = "EV/trade:",
                    ["zh"] = "EV/交易：",
                    ["hi"] = "EV/ट्रेड:",
                    ["ar"] = "القيمة المتوقعة/صفقة:",
                    ["ru"] = "EV/сделку:"
                },
                ["FixedOf"] = new()
                {
                    ["en"] = "fixed of",
                    ["pt"] = "fixo de",
                    ["es"] = "fijo de",
                    ["zh"] = "固定为",
                    ["hi"] = "निश्चित",
                    ["ar"] = "ثابت بـ",
                    ["ru"] = "фиксировано в"
                },
                ["ToMaintain"] = new()
                {
                    ["en"] = "to maintain",
                    ["pt"] = "de manter",
                    ["es"] = "de mantener",
                    ["zh"] = "保持",
                    ["hi"] = "बनाए रखने का",
                    ["ar"] = "للمحافظة على",
                    ["ru"] = "поддерживать"
                },
            };

        public SimpleTranslationService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string this[string key]
        {
            get
            {
                var culture = GetCurrentCultureTwoLetters();

                if (_translations.TryGetValue(key, out var byCulture))
                {
                    // 1) cultura atual
                    if (byCulture.TryGetValue(culture, out var text))
                        return text;

                    // 2) fallback para inglês
                    if (byCulture.TryGetValue("en", out var en))
                        return en;
                }

                // 3) fallback final: a própria chave
                return key;
            }
        }

        private string GetCurrentCultureTwoLetters()
        {
            var ctx = _httpContextAccessor.HttpContext;
            var feature = ctx?.Features.Get<IRequestCultureFeature>();
            var culture = feature?.RequestCulture.UICulture
                          ?? CultureInfo.CurrentUICulture;
            return culture.TwoLetterISOLanguageName.ToLowerInvariant();
        }
    }
}
