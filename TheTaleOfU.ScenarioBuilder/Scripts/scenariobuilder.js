$(document).ready(function () {
    var ScenarioOptionContainerTemplate = `<div class="t-collapsable t-option"> <div class="t-collapsable-head"> <span class="fa fa-chevron-down js-optionchevron fa-2x"></span> <input type="text" placeholder="Enter option name"> </div><div class="t-collapsable-content"> <div class="t-clearfix"> <div class="t-collapsable-form"> <p>Option text</p><input class="t-input js-optiontext" placeholder="Please enter some option text"><br><div class="hexagon-holder"> <div class="hexagon"> </div><p class="hexagon-text"> Add effect </p><span class="fa fa-vial fa-2x fa-hexagon-icon"></span> </div><div class="hexagon-holder"> <div class="hexagon"> </div><p class="hexagon-text"> Add enemy </p><span class="fa fa-user-ninja fa-2x fa-hexagon-icon"></span> </div><p style="margin-top: 25px;"> Add next step (optional) </p><div class="t-select" style="width: 80%;"><select class="js-scenariolinkdropdown" tabindex="-1"> </select> </div></div></div></div></div>`;
    rebind();


    function rebind() {
        $(".js-optionchevron").unbind();
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


    $(".js-addoption").on("click", function () {
        AddOption();
        rebind();
    });


    var AddOption = function () {
        $.each($(".js-optionchevron"), function (i, value) {
            $(value).removeClass("fa-chevron-down");
            $(value).addClass("fa-chevron-up");
            $(value).parents(".t-option").children(".t-collapsable-content").fadeOut();
            $(this).parents(".t-option").children(".t-collapsable-head").addClass("t-collapsable-head-closed");
        });
        $(".js-addedoptions").append(ScenarioOptionContainerTemplate);
    }

    var getOption = function (element) {
        element = $(element);
        var optionText = $(element).closest(".js-optiontext");
        var linkedScenario = $(element).closest(".js-scenariolinkdropdown").find("option:selected").val();
        //TODO include attached effect

        return { OptionText: optionText, LinkedScenarioName: linkedScenario };
    };

});