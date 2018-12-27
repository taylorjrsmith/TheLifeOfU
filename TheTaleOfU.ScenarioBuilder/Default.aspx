<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TheTaleOfU.ScenarioBuilder._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container body-content">
        <div class="t-box" style="width: 1500px; height: 850px; color: white; background-color: white; opacity: 0.9; margin: 0 !important; position: absolute; top: 60px; left: 25px; border-radius: 15px; border: 2px solid lavenderblush; position: absolute;">
            <img src="/assets/logo.png" style="width: 200px; position: absolute; top: 0; left: 0; margin: 20px;">

            <img src="/assets/sblogo.png" class="sblogo">
            <div class="t-form t-form-40">
                <p>Scenario Name</p>
                <input class="t-input" placeholder="Please enter a scenario name">
                <p>Scenario Text</p>
                <textarea class="t-input t-textarea" placeholder="Please enter a scenario text"></textarea>
            </div>
            <div class="t-form t-form-50">

                <span class="fa fa-plus-circle fa-3x fa-custom js-addoption"></span>
                <p>Add Option</p>
                <div class="js-addedoptions">
                    <div class="t-collapsable t-option">
                        <div class="t-collapsable-head ">
                            <span class="fa js-optionchevron fa-2x fa-chevron-down"></span>
                            <input type="text" placeholder="Enter option name">
                        </div>
                        <div class="t-collapsable-content" style="">
                            <div class="t-clearfix">
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





                                    <p style="margin-top: 25px;">
                                        Add next step (optional)
                                    </p>
                                    <div class="t-select" style="width: 80%;">
                                        <select class="js-scenariolinkdropdown" tabindex="-1">
                                        </select>
                                    </div>
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
            <h6>Created Scenarios</h6>
            <hr>

            <div class="list-items">
                <table class="created-senario-list table">
                    <tbody>
                        <tr>
                            <td class="item">
                                <h5>Test</h5>
                            </td>
                        </tr>
                        <tr>
                            <td class="item">
                                <h5>Test</h5>
                            </td>
                        </tr>
                        <tr>
                            <td class="item">
                                <h5>Test</h5>
                            </td>
                        </tr>

                    </tbody>
                </table>
            </div>
        </div>





        <div class="add-to-tree">
            <a class="waves-effect waves-light btn">Add to senario tree</a>
        </div>
    </div>


    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"></script>
    <script src="main.js"></script>
    <script src="Scripts/scenariobuilder.js"></script>

    </div>

</asp:Content>
