$(document).ready(function () {
    var ScenarioOptionContainerTemplate = `<div class="t-collapsable t-option"> <div class="t-collapsable-head"> <span class="fa fa-chevron-down fa-2x"></span> <p> Option 1 </p></div><div class="t-collapsable-content"> <div class="t-clearfix"> <div class="t-collapsable-form"> <p>Scenario Name</p><input class="t-input" placeholder="Please enter a scenario name"><br><div class="t-button"> <span class="fa fa-vial fa-3x"></span><span class="t-icontext">Add Effect</span> </div><p>Add a linked scenario (optional)</p><div class="t-select" style="width: 80%;"> <select class="js-scenariolinkdropdown" tabindex="-1"> </select> </div></div></div></div></div>`;


    $(".js-optionchevron").on("click", function () {
        var isOpen = $(this).hasClass("fa-chevron-down");

        if (isOpen) {
            $(this).parents(".t-option").children(".t-collapsable-content").fadeOut();
            $(this).removeClass("fa-chevron-down");
            $(this).addClass("fa-chevron-up");
        } else {
            $(this).parents(".t-option").children(".t-collapsable-content").fadeIn();
            $(this).removeClass("fa-chevron-up");
            $(this).addClass("fa-chevron-down");
        }
    });

    $(".js-addoption").on("click", function () {
        AddOption();
    });


    var AddOption = function () {
        $.each($(".js-optionchevron"), function (i, value) {
            $(value).removeClass("fa-chevron-down");
            $(value).addClass("fa-chevron-up");
            $(value).parents(".t-option").children(".t-collapsable-content").fadeOut();
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