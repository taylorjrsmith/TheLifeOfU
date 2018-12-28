﻿$(document).ready(function () {
    var ScenarioOptionContainerTemplate = $(".t-option").parent().html();
    $('select').formSelect();
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
        var constructedScenario = constructScenario();
        console.log(constructedScenario);
        scenarioList.push(constructedScenario);
        $(".created-senario-list").append("<tr><td class='item'><h5>" + constructedScenario.ScenarioName + "</h5></td></tr>");

    });


    function populateScenario(scenario) {
        $(".js-scenarioname").val(scenario.ScenarioName);
        $(".js-scenariodescription").val(scenario.ScenarioDescription);

        $.each(scenario.Options, function (i, value) {
            $(".js-addedoptions").append(ScenarioOptionContainerTemplate);
            var option = $("t-option").last();
            var currentForm = $(option).parents(".t-option").children(".t-collapsable-content").children(".t-clearfix").children(".t-collapsable-form");
            currentForm.children(".js-optiontext").val(value.OptionText);
            $(element).children(".t-collapsable-head").find("input").val(value.OptionName);
            //todo populate the dropdown
        });
    }


    function rebind() {
        $(".js-optionchevron").unbind();
        $(".js-hexagon-delete").unbind();

        $(".js-hexagon-delete").on("click", function () {
            $(this).closest(".t-option").remove();
            if ($(".js-option").length === 0)
                setAddOptionEnabled();
        })

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

        $('select').formSelect();
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


    var AddOption = function () {
        var canAppend = true;

        $.each($(".js-optionchevron"), function (i, value) {
            canAppend = checkOptionIsPopulated($(value));
            if (!canAppend)
                return;
            $(value).removeClass("fa-chevron-down");
            $(value).addClass("fa-chevron-up");
            $(value).parents(".t-option").children(".t-collapsable-content").fadeOut();
            $(this).parents(".t-option").children(".t-collapsable-head").addClass("t-collapsable-head-closed");
        });
        if (canAppend)
            $(".js-addedoptions").append(ScenarioOptionContainerTemplate);
    }

    var getOption = function (element) {
        element = $(element);
        var currentForm = $(element).parents(".t-option").children(".t-collapsable-content").children(".t-clearfix").children(".t-collapsable-form");
        var optionText = currentForm.children(".js-optiontext").val();
        var optionName = $(element).parents(".t-collapsable-head").find("input").val();
        var linkedScenario = currentForm.children(".js-scenariolinkdropdown").find("option:selected").val();
        //TODO include attached effect

        return { OptionText: optionText, LinkedScenarioName: linkedScenario, OptionName: optionName };
    };

});