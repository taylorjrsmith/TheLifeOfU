<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TheTaleOfU.ScenarioBuilder._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container body-content">

        <style>
            /* style the elements with CSS */
            #pleaserotate-graphic {
                fill: #fff;
            }

            #pleaserotate-backdrop {
                color: #fff;
                background-color: #000;
            }
        </style>

        <div class="t-box" style="width: 1500px; height: 850px; color: white; background-color: white; opacity: 0.9; margin: 0 !important; position: absolute; top: 60px; left: 25px; border-radius: 15px; border: 2px solid lavenderblush; position: absolute;">
            <img src="/assets/logo.png" style="width: 200px; position: absolute; top: 0; left: 0; margin: 20px;">

            <img src="/assets/sblogo.png" class="sblogo">

            <div class="taskbar-control" style="position: absolute; width: 50px; height: 80px; right: 0; background-color: #41afc6; border-radius: 0px 15px 0px 0px; border: 2px solid #002e3f;">
                <span class="fa js-lr-chevron fa-chevron-right" style="position: absolute; top: 12.5px; left: 5px; font-size: 50px;"></span>
            </div>

            <div class="taskbar" style="width: 500px; height: 80px; position: absolute; border-top: 2px solid black; border-bottom: 2px solid black; border-left: 2px solid black; border-image: initial; right: 0px; top: 0px; border-radius: 15px 0px 0px 15px; margin-right: 50px; border-right: none;">

                <div style="position: relative; height: 100%; width: 100%; background-color: #002e3f; border-radius: inherit; border: 1px solid;">

                    <div class="hexagon-holder js-addoption" style="/* right: 0; */
    /* top: 0; */
    /* position: absolute; */
    position: relative; float: right; right: 10px;">
                        <div class="hexagon " style="/* right: 10px; */
    margin-left: 10px; margin-right: 10px;">
                        </div>

                        <span class="fa fa-plus fa-2x fa-hexagon-icon" style="margin-left: 10px;"></span>

                    </div>

                    <div class="hexagon-holder" style="/* right: 0; */
    /* top: 0; */
    /* position: absolute; */
    position: relative; float: right; right: 10px;">
                        <div class="hexagon" style="/* right: 10px; */
    margin-left: 10px; margin-right: 10px;">
                        </div>

                        <span class="fa fa-cogs fa-2x fa-hexagon-icon"></span>

                    </div>
                </div>

            </div>






            <div class="t-form t-form-40">
                <p>Scenario Name</p>
                <input class="t-input js-scenarioname" placeholder="Please enter a scenario name">
                <p>Scenario Text</p>
                <textarea class="t-input t-textarea js-scenariodescription" placeholder="Please enter a scenario text"></textarea>
            </div>
            <div class="t-form t-form-50">
                <div class="js-addedoptions">
                    <div class="t-collapsable t-option">
                        <div class="t-collapsable-head ">
                            <span class="fa js-optionchevron fa-2x fa-chevron-down"></span>
                            <input type="text" class="js-optionname" placeholder="Enter option name">
                        </div>
                        <div class="t-collapsable-content">
                            <div class="t-collapsable-form">
                                <p>Option text</p>
                                <input class="t-input js-optiontext" placeholder="Please enter some option text"><br>




                                <div class="hexagon-holder">
                                    <div class="hexagon">
                                    </div>
                                    <p class="hexagon-text">
                                        Add effect
                                    </p>
                                    <span class="fa fa-vial fa-2x fa-hexagon-icon"></span>
                                </div>


                                <div class="hexagon-holder">

                                    <div class="hexagon">
                                    </div>

                                    <p class="hexagon-text">
                                        Add enemy
                                    </p>
                                    <span class="fa fa-user-ninja fa-2x fa-hexagon-icon"></span>
                                </div>

                                <div class="hexagon-holder">

                                    <div class="hexagon">
                                    </div>

                                    <p class="hexagon-text">
                                        Gain item
                                    </p>
                                    <span class="fa fa-suitcase fa-2x fa-hexagon-icon"></span>
                                </div>

                                <p style="margin-top: 25px;">
                                    Add next step (optional)
                                </p>
                                <div class="t-select" style="width: 80%;">
                                    <select class="js-scenariolinkdropdown" tabindex="-1">
                                    </select>
                                </div>

                                <div class="hexagon-small-holder js-hexagon-delete">
                                    <div class="hexagon-small hexagon-small-pos" style="position: absolute; right: 25px; bottom: 5px;">
                                    </div>
                                    <span class="fa fa-trash-alt fa-delete"></span>
                                </div>
                            </div>


                        </div>

                    </div>
                </div>

            </div>
        </div>

    </div>
    <div class="container">
        <!--Center div-->
        <div class="created-scenario-container">
            <h6 style="text-align: center;">Created Scenarios</h6>
            <hr>

            <div class="list-items">
                <table class="created-senario-list table">
                    <tbody>
                    </tbody>
                </table>
            </div>
        </div>





        <div class="add-to-tree">
            <a class="waves-effect waves-light btn js-addscenariototree">Update scenario tree</a>
        </div>
    </div>


    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"></script>
    <script src="main.js"></script>
    <script src="Scripts/scenariobuilder.js"></script>

    </div>

</asp:Content>
