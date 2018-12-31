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
            $(".created-senario-list").append("<tr><td class='item'><h5>" + constructedScenario.ScenarioName + "</h5></td></tr>");
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
        scenarioList.forEach(function (scenario) {
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