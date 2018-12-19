<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TheTaleOfU.ScenarioBuilder._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container body-content">
        <div class="t-box" style="width: 1500px; height: 850px; color: white; background-color: white; opacity: 0.9; margin: 0 !important; position: absolute; top: 60px; left: 25px; border-radius: 15px; border: 2px solid lavenderblush; position: absolute;">
            <img src="/assets/logo.png" style="width: 200px; position: absolute; top: 0; left: 0; margin: 20px;">

            <img src="/assets/sblogo.png" style="position: absolute; width: 20%; margin: auto !important; display: block;">
            <div class="t-form" style="position: relative; top: 120px; z-index: 100; color: grey; margin-left: 50px; width: 40%; display: inline-block; float: left;">
                <p>Scenario Name</p>
                <input class="t-input" placeholder="Please enter a scenario name" style="width: 80%;">
                <p>Scenario Text</p>
                <textarea class="t-input t-textarea" placeholder="Please enter a scenario text" style="width: 80%;"></textarea>
            </div>
            <div class="t-form" style="position: relative; top: 120px; z-index: 100; color: grey; margin-left: 50px; width: 50%; display: inline-block;">

                <span class="fa fa-plus-circle fa-3x fa-custom"></span><p>Add Option</p>
            </div>

        </div>
        <div class="container">
            <!--Center div-->
            <div class="created-senario-container" style="color: white; opacity: 0.7;">
                <h6>Created Senarios</h6>
                <hr style="width: 80%;">

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
                <a class="waves-effect waves-light btn" style="/* position: absolute; */
    bottom: 50px; right: 30px;">Add to senario tree</a>
            </div>
        </div>


        <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"></script>
        <script src="main.js"></script>

    </div>

</asp:Content>
