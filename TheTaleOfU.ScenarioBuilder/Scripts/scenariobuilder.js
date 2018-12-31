PleaseRotateOptions = {
    forcePortrait: false,
    forceLandscape: true
}

$(document).ready(function () {
    var ScenarioOptionContainerTemplate = $(".t-option").parent().html();

    setAddOptionDisabled();
    rebind();

    var scenarioList = [];


    $(".js-lr-chevron").on("click", function () {
        if ($(this).hasClass("fa-chevron-right")) {
            $(this).removeClass("fa-chevron-right");
            $(this).addClass("fa-chevron-left");
        }
        else {
            $(this).removeClass("fa-chevron-left");
            $(this).addClass("fa-chevron-right");
        }
        $(".taskbar").animate({ width: 'toggle' }, 350);
    });


    $(".js-addscenariototree").on("click", function () {
        updateScenarioTree();
    });

    function updateScenarioTree() {
        var constructedScenario = constructScenario();
        console.log(constructedScenario);
        var filteredList = scenarioList.filter(function (scenario) { return scenario.ScenarioName === constructedScenario.ScenarioName; });

        if (filteredList.length > 0) {
            scenarioList = scenarioList.filter(function (scenario) { return scenario.ScenarioName !== constructedScenario.ScenarioName; });
        } else {
            $(".created-senario-list").append("<tr><td class='item'><h5>" + constructedScenario.ScenarioName + "</h5><div class='dot' data-position='right'></div></td></tr>");

        }
        scenarioList.push(constructedScenario);
        rebind();

    }


    function populateScenario(scenario) {
        $(".js-scenarioname").val(scenario.ScenarioName);
        $(".js-scenariodescription").val(scenario.ScenarioDescription);

        $.each(scenario.Options, function (i, value) {
            $(".js-addedoptions").append(ScenarioOptionContainerTemplate);
            var option = $(".t-option").last();
            var optionChevron = $(".js-optionchevron").last();
            var currentForm = $(option).children(".t-collapsable-content").children(".t-clearfix").children(".t-collapsable-form");
            currentForm.children(".js-optiontext").val(value.OptionText);
            $(option).children(".t-collapsable-head").find("input").val(value.OptionName);
            closeOption(optionChevron);
            populateDropdown(option);
            //todo populate the dropdown
        });
        openOption($(".js-optionchevron").first());
        rebind(true);
    }

    var appendStatusClassForScenario = function (scenarioName) {
        var scenario = scenarioList.filter(function (scenario) { return scenario.ScenarioName === scenarioName; })[0];

        var scenarioTableRow = $(".item").find("h5:contains(" + scenarioName + ")").parents(".item").children(".dot");

        var incompleteOptions = scenario.Options.filter(function (currentOption) { return currentOption.LinkedScenarioName === "" || currentOption.LinkedScenarioName === undefined; });

        if (incompleteOptions.length == 0) {
            scenarioTableRow.addClass("dot-complete");
            scenarioTableRow.removeClass("dot-incomplete");
            scenarioTableRow.attr("data-tooltip", "all options set");
        } else {
            scenarioTableRow.addClass("dot-incomplete");
            scenarioTableRow.removeClass("dot-complete");
            scenarioTableRow.attr("data-tooltip", "options need next steps");
        }
    };


    function populateDropdown(tOption) {
        var scenarioName = $(".js-scenarioname").val();
        var currentScenario = scenarioList.filter(function (scenario) { return scenario.ScenarioName === scenarioName; })[0];
        var option = $(tOption);
        var currentForm = $(option).children(".t-collapsable-content").children(".t-clearfix").children(".t-collapsable-form");
        var dropdown = currentForm.children(".t-select").children(".js-scenariolinkdropdown");
        var dropdownValue = dropdown.find("option:selected");
        dropdown.data("previousValue", dropdownValue);
        $.each(dropdown.find("option"), function (i, value) {
            $(value).remove();
        });
        scenarioList.filter(function (scenario) { return scenario.ScenarioName !== scenarioName; }).forEach(function (scenario) {
            dropdown.append("<option value=" + scenario.ScenarioName + ">" + scenario.ScenarioName + "</option>");
        });

        var optionName = currentForm.children(".js-optiontext").val();
        var optionLinkedScenario = currentScenario.Options.filter(function (option) { return option.OptionName === optionName; })[0];

        if (optionLinkedScenario !== "" || optionLinkedScenario !== undefined)
            dropdown.find("option:contains(" + optionLinkedScenario.LinkedScenarioName + ")").prop("selected", true);

        $('select').formSelect();

    }


    function filterScenarioByScenarioName(scenario, scenarioName) {
        return scenario.ScenarioName === scenarioName;
    }

    function rebind(doNotRebindSelect) {
        $(".js-optionchevron").unbind();
        $(".js-hexagon-delete").unbind();
        $(".item").unbind();

        $(".js-hexagon-delete").on("click", function () {
            $(this).closest(".t-option").remove();
            if ($(".js-option").length === 0)
                setAddOptionEnabled();
        });

        $(".item").on("click", function () {
            updateScenarioTree();
            $(".t-option").each(function (i, value) {
                $(value).remove();
            });

            var scenarioName = $(this).find("h5").text();
            var scenario = scenarioList.filter(function (scenario) { return scenario.ScenarioName == scenarioName });
            console.log(scenario);
            populateScenario(scenario[0]);

        });

        $(".js-optiontext, .js-optionname").on("blur", function () {
            if (checkOptionIsPopulated($(this)))
                setAddOptionEnabled();
            else
                setAddOptionDisabled();
        });

        $(".js-optionchevron").on("click", function () {
            var isOpen = $(this).hasClass("fa-chevron-down");

            if (isOpen) {
                $(this).parents(".t-option").children(".t-collapsable-content").fadeOut();
                $(this).parents(".t-option").children(".t-collapsable-head").addClass("t-collapsable-head-closed");
                $(this).removeClass("fa-chevron-down");
                $(this).addClass("fa-chevron-up");
            } else {
                $(this).parents(".t-option").children(".t-collapsable-content").fadeIn();
                $(this).parents(".t-option").children(".t-collapsable-head").removeClass("t-collapsable-head-closed");
                $(this).removeClass("fa-chevron-up");
                $(this).addClass("fa-chevron-down");
            }

        });

        if (!doNotRebindSelect)
            $('select').formSelect();



        $.each(scenarioList, function (i, value) {
            appendStatusClassForScenario(value.ScenarioName);
        });

        $(".dot").tooltip();
    }


    function setAddOptionDisabled() {
        $(".js-addoption").find(".hexagon").css("background-color", "lightgray");
    }

    function setAddOptionEnabled() {
        $(".js-addoption").find(".hexagon").css("background-color", "#a936f1");
    }


    $(".js-addoption").on("click", function () {
        AddOption();
        setAddOptionDisabled();
        rebind();
    });

    var checkOptionIsPopulated = function (element) {
        var option = getOption($(element));
        if (option.OptionText !== "" && option.OptionName !== "")
            return true;
    }


    var constructScenario = function () {
        var scenarioName = $(".js-scenarioname").val();
        var scenarioDescription = $(".js-scenariodescription").val();
        var options = [];

        $.each($(".js-optionname"), function (i, value) {
            var option = getOption($(value));
            options.push(option);
        });

        return { ScenarioName: scenarioName, ScenarioDescription: scenarioDescription, Options: options };
    };

    var closeOption = function (option) {
        $(option).removeClass("fa-chevron-down");
        $(option).addClass("fa-chevron-up");
        $(option).parents(".t-option").children(".t-collapsable-content").fadeOut();
        $(option).parents(".t-option").children(".t-collapsable-head").addClass("t-collapsable-head-closed");
    }

    var openOption = function (option) {
        $(option).removeClass("fa-chevron-up");
        $(option).addClass("fa-chevron-down");
        $(option).parents(".t-option").children(".t-collapsable-content").fadeIn();
        $(option).parents(".t-option").children(".t-collapsable-head").removeClass("t-collapsable-head-closed");
    }


    var AddOption = function () {
        var canAppend = true;

        $.each($(".js-optionchevron"), function (i, value) {
            canAppend = checkOptionIsPopulated($(value));
            if (!canAppend)
                return;
            closeOption($(value));
        });
        if (canAppend)
            $(".js-addedoptions").append(ScenarioOptionContainerTemplate);
    }

    var getOption = function (element) {
        element = $(element);
        var currentForm = $(element).parents(".t-option").children(".t-collapsable-content").children(".t-clearfix").children(".t-collapsable-form");
        var optionText = currentForm.children(".js-optiontext").val();
        var optionName = $(element).parents(".t-collapsable-head").find("input").val();
        var linkedScenario = currentForm.children(".t-select").find(".js-scenariolinkdropdown").find("option:selected").val();
        //TODO include attached effect

        return { OptionText: optionText, LinkedScenarioName: linkedScenario, OptionName: optionName };
    };

});


!function () { function a(a) { var b; for (var b in a) o[b] = a[b] } function b(a) { document.documentElement && (document.documentElement.className = document.documentElement.className.replace(/(?:^|\s)pleaserotate-\S*/g, ""), document.documentElement.className += " pleaserotate-" + a) } function c(a) { var b; for (b = 0; b < p.length; b++)a.insertRule(p[b], 0); for (a.insertRule("#pleaserotate-backdrop { z-index: " + o.zIndex + "}", 0), o.allowClickBypass && a.insertRule("#pleaserotate-backdrop { cursor: pointer }", 0), o.forcePortrait && a.insertRule("#pleaserotate-backdrop { -webkit-transform-origin: 50% }", 0), b = 0; b < q.length; b++)CSSRule.WEBKIT_KEYFRAMES_RULE ? a.insertRule("@-webkit-keyframes " + q[b], 0) : CSSRule.MOZ_KEYFRAMES_RULE ? a.insertRule("@-moz-keyframes " + q[b], 0) : CSSRule.KEYFRAMES_RULE && a.insertRule("@keyframes " + q[b], 0) } function d() { var a = document.createElement("style"); a.appendChild(document.createTextNode("")), document.head.insertBefore(a, document.head.firstChild), c(a.sheet) } function e() { var a = document.createElement("div"), b = document.createElement("div"), c = document.createElement("div"), d = document.createElement("small"); a.setAttribute("id", "pleaserotate-backdrop"), b.setAttribute("id", "pleaserotate-container"), c.setAttribute("id", "pleaserotate-message"), a.appendChild(b), b.appendChild(null !== o.iconNode ? o.iconNode : f()), b.appendChild(c), c.appendChild(document.createTextNode(o.message)), d.appendChild(document.createTextNode(o.subMessage)), c.appendChild(d), document.body.appendChild(a) } function f() { var a = document.createElementNS("http://www.w3.org/2000/svg", "svg"); a.setAttributeNS("http://www.w3.org/2000/xmlns/", "xmlns:xlink", "http://www.w3.org/1999/xlink"), a.setAttribute("id", "pleaserotate-graphic"), a.setAttribute("viewBox", "0 0 250 250"); var b = document.createElementNS("http://www.w3.org/2000/svg", "g"); b.setAttribute("id", "pleaserotate-graphic-path"), o.forcePortrait && b.setAttribute("transform", "rotate(-90 125 125)"); var c = document.createElementNS("http://www.w3.org/2000/svg", "path"); return c.setAttribute("d", "M190.5,221.3c0,8.3-6.8,15-15,15H80.2c-8.3,0-15-6.8-15-15V28.7c0-8.3,6.8-15,15-15h95.3c8.3,0,15,6.8,15,15V221.3zM74.4,33.5l-0.1,139.2c0,8.3,0,17.9,0,21.5c0,3.6,0,6.9,0,7.3c0,0.5,0.2,0.8,0.4,0.8s7.2,0,15.4,0h75.6c8.3,0,15.1,0,15.2,0s0.2-6.8,0.2-15V33.5c0-2.6-1-5-2.6-6.5c-1.3-1.3-3-2.1-4.9-2.1H81.9c-2.7,0-5,1.6-6.3,4C74.9,30.2,74.4,31.8,74.4,33.5zM127.7,207c-5.4,0-9.8,5.1-9.8,11.3s4.4,11.3,9.8,11.3s9.8-5.1,9.8-11.3S133.2,207,127.7,207z"), a.appendChild(b), b.appendChild(c), a } function g(a) { var b = document.getElementById("pleaserotate-backdrop"); a ? b && (b.style.display = "block") : b && (b.style.display = "none") } function h() { var a, c = l && !o.forcePortrait || !l && o.forcePortrait; c ? (a = o.onShow(), b("showing")) : (a = o.onHide(), b("hiding")), (void 0 === a || a) && (k.Showing = c, g(c)) } function i() { return window.innerWidth < window.innerHeight } function j() { return !m && o.onlyMobile ? void (n || (n = !0, g(!1), b("hiding"), o.onHide())) : void (l !== i() && (l = i(), h())) } var k = {}, l = null, m = /Android|iPhone|iPad|iPod|IEMobile|Opera Mini/i.test(navigator.userAgent), n = !1, o = { startOnPageLoad: !0, onHide: function () { }, onShow: function () { }, forcePortrait: !1, message: "Please Rotate Your Device", subMessage: "(or click to continue)", allowClickBypass: !0, onlyMobile: !0, zIndex: 1e3, iconNode: null }, p = ["#pleaserotate-graphic { margin-left: 50px; width: 200px; animation: pleaserotateframes ease 2s; animation-iteration-count: infinite; transform-origin: 50% 50%; -webkit-animation: pleaserotateframes ease 2s; -webkit-animation-iteration-count: infinite; -webkit-transform-origin: 50% 50%; -moz-animation: pleaserotateframes ease 2s; -moz-animation-iteration-count: infinite; -moz-transform-origin: 50% 50%; -ms-animation: pleaserotateframes ease 2s; -ms-animation-iteration-count: infinite; -ms-transform-origin: 50% 50%; }", "#pleaserotate-backdrop { background-color: white; top: 0; left: 0; position: fixed; width: 100%; height: 100%; }", "#pleaserotate-container { width: 300px; position: absolute; top: 50%; left: 50%; margin-right: -50%; transform: translate(-50%, -50%); -webkit-transform: translate(-50%, -50%); }", "#pleaserotate-message { margin-top: 20px; font-size: 1.3em; text-align: center; font-family: Verdana, Geneva, sans-serif; text-transform: uppercase }", "#pleaserotate-message small { opacity: .5; display: block; font-size: .6em}"], q = ["pleaserotateframes{ 0% { transform:  rotate(0deg) ; -moz-transform:  rotate(0deg) ;-webkit-transform:  rotate(0deg) ;-ms-transform:  rotate(0deg) ;} 49% { transform:  rotate(-90deg) ;-moz-transform:  rotate(-90deg) ;-webkit-transform:  rotate(-90deg) ; -ms-transform:  rotate(-90deg) ;  } 100% { transform:  rotate(-90deg) ;-moz-transform:  rotate(-90deg) ;-webkit-transform:  rotate(-90deg) ; -ms-transform:  rotate(-90deg) ;  } }"]; k.start = function (c) { return document.body ? (c && a(c), d(), e(), j(), window.addEventListener("resize", j, !1), void (o.allowClickBypass && document.getElementById("pleaserotate-backdrop").addEventListener("click", function () { var a = o.onHide(); b("hiding"), k.Showing = !1, (void 0 === a || a) && g(!1) }))) : void window.addEventListener("load", k.start.bind(null, c), !1) }, k.stop = function () { window.removeEventListener("resize", onWindowResize, !1) }, k.onShow = function (a) { o.onShow = a, n && (n = !1, l = null, j()) }, k.onHide = function (a) { o.onHide = a, n && (l = null, n = !1, j()) }, k.Showing = !1, "function" == typeof define && define.amd ? (b("initialized"), define(["PleaseRotate"], function () { return k })) : "object" == typeof exports ? (b("initialized"), module.exports = k) : (b("initialized"), window.PleaseRotate = k, a(window.PleaseRotateOptions), o.startOnPageLoad && k.start()) }();