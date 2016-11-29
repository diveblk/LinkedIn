(function () {
    'use strict';
    var app = angular.module("Meals");
    var Recipient = function ($scope, $log, $stateParams, $state, recipientService, $mdSidenav, miscService, $mdDialog, commentService) {

        var id = String($stateParams.id);

        //recipientService.updateNok(nok object).then()
        //recipientService.updateEmergency(emr object).then()
        //recipientService.deleteEmergency(EmergencyID).then()
        //recipientService.deleteNok(NextOfKinID).then()

// commentService.getComment = function (id)
// commentService.deleteComment = function (id)
// commentService.updateComment = function (comment)
// commentService.insertComment = function (comment)

$scope.comments = {

"CommentID":"",
"RecipientID":"",
"Date":"",
"COMMENTS":""

}

        $scope.pageSize = 6;
        $scope.Day1stOn;
        $scope.deleteMode = false;
        $scope.routes = { "Value1": "" };
        $scope.refferedBy = { "Value1": "", "Value2": "" };

        $scope.reci = {
            "RecipientID": "",
            "LAST_NAME": "",
            "FIRST_NAME": "",
            "MID_NAME": "",
            "TITLE": "",
            "STREET_1": "",
            "STREET_2": "",
            "CITY": "",
            "STATE": "",
            "ZIP": "",
            "HomePhoneAreaCode": "",
            "HOME_PHONE": "",
            "BIRTH_DATE": "",
            "PHYS_COND": "",
            "Date_Start": "",
            "ETHNIC_INF": "",
            "SEX": "",
            "MAR_STATUS": "",
            "SPOUSE_ON": "",
            "SpouseRecipientNum": "",
            "ACTIVE_Y_N": "",
            "COMMENTS": "",
            "PAYING_Y_N": "",
            "WHO_PAYS": "",
            "FIN_CONDTN": "",
            "REFERD_BY": "",
            "REF_HME_PH": "",
            "REF_WRK_PH": "",
            "DEL_INST": "",
            "DEL_INST_2": "",
            "RouteNumber": "",
            "ROUTE_SEQ": "",
            "AUTH_BY": "",
            "SPECIAL": "",
            "DeliveryDays": "",
            "DIET_Y_N": "",
            "DIET_TYPE": "",
            "DeliverFrozenMeals": "",
            "OffDays": "",
            "SackMealType": "",
            "Date1stOn": "",
            "Date_Start": "",
            "Date_Off": "",
            "Reason_Off": "",
            "ModificationDate": "",
            "CellPhoneAreaCode": "",
            "CellPhone": "",
            "email": "",
            "Temp": "",
            "Veteran": "",

            "Referred_By ": "",
            "Contact ": "",
            "Dr_Letter ": "",
            "Dr_Name ": "",
            "N_KIN_CITY ": "",
            "NOK_HME_PH ": "",
            "NOK_WRK_PH ": "",
            "NOKCellPhone ": "",
            "NOK_TYPE ": "",
            "NOK_ADDR_1 ": "",
            "NOK_ADDR_2 ": "",
            "Doctors_Name ": "",
            "Doctors_Phone_No ": "",
            "Doctors_Comments ": "",
            "EMR_CON_1 ": "",
            "EMR_CON1HM ": "",
            "EMR_CON1WK ": "",
            "EmergCellPhone ": "",
            "Route_Number ": "",
            "ROUTE_SEQ ": "",
            "Delivery_Days ": "",
            "Deliver_Frozen_Meals ": "",
            "Off_Days ": "",
            "Sack_Meal_Type ": "",
            "Breakfast_Sacks ": "",
            "Friday_Sacks ": "",
            "Deliver_Monday ": "",
            "Deliver_Tuesday ": "",
            "Deliver_Wednesday ": "",
            "Deliver_Thursday ": "",
            "Deliver_Friday ": "",
            "Frozen_Mon ": "",
            "Frozen_Tue ": "",
            "Frozen_Wed ": "",
            "Frozen_Thurs ": "",
            "Frozen_Fri ": "",
            "Off_Mon ": "",
            "Off_Tue ": "",
            "Off_Wed ": "",
            "Off_Thurs ": "",
            "Off_Fri ": "",
            "Pets ": "",
            "Dogs ": "",
            "Cats ": "",
            "Pet_Comments ": "",
            "Pet_Route_Number ": "",
            "Pet_Sequence ": "",
            "Smoke_Detector ": "",
            "Smoke_Alarm_Inst ": "",
            "Need_Fan ": "",
            "Fan_Delivered ": "",
            "Need_Heater ": "",
            "Heater_Delivered ": "",
            "Need_Microwave ": "",
            "Microwave_Delivered ": "",
            "Lives_Alone ": "",
            "No_In_Household ": "",
            "Risk_Level_Comments ": "",
            "Risk_Level ": "",
            "Home_Visit_Date ": "",
            "Assessment_Comments ": "",
            "Misc_Info_Veteran ": "",
            "VetComments ": ""

        }

        $scope.Comments = {
            "CommentID": "",
            "RecipientID": "",
            "Date": "",
            "COMMENTS":""
        }

        $scope.CommentsAdd = {
            "addCommentDate": "",
            "addComment": "",
        }

        $scope.EmergencyContactAdd = {
            "addEMR_CON_1": "",
            "addEMR_CON1HM": "",
            "addEMR_CON1WK": "",
            "addEmergCellPhone": ""
        }

        $scope.NextOfKinAdd = {
            "addN_KIN_CITY": "",
            "addNOK_HME_PH": "",
            "addNOK_WRK_PH": "",
            "addNOKCellPhone": "",
            "addNOK_TYPE": "",
            "addNOK_ADDR_1": "",
            "addNOK_ADDR_2": ""
        }

        $scope.EmergencyContact = {
            "EmergencyID": "",
            "EMR_CON_1": "",
            "EMR_CON1HM": "",
            "EMR_CON1WK": "",
            "EmergCellPhone": ""

        }

        $scope.NextOfKin = {
            "NextOfKinID": "",
            "N_KIN_CITY": "",
            "NOK_HME_PH": "",
            "NOK_WRK_PH": "",
            "NOKCellPhone": "",
            "NOK_TYPE": "",
            "NOK_ADDR_1": "",
            "NOK_ADDR_2": ""
        }


        //$scope.toggleLeft = buildDelayedToggler('left');

        $scope.toggleMealsOptions = function () {
            $mdSidenav('MealsOptions').toggle();
        }

        //$scope.referedBy = ('Adult Protective Services ,Angels Care Home Health ,Area Agency on Aging ,Baptist Affilate ,Department of Aging and Disability Services ,Encompass Home Health ,Family ,Friend ,Girling Health Care ,Hospice of San Angelo ,Husband/Wife ,InHome Care ,IntegraCare Home Health ,Interim Health Care ,Intrepid Home Health ,La Esperanza ,Medway Home Healthcare ,MHMR ,Neighbor ,Nurses Unlimited ,Odyssey Hospice ,Outreach Health Services ,S.A. Community Med. Center ,San Angelo Home Health ,Self ,Shannon Clinic ,Shannon Home Health ,Shannon Medical Center ,Shannon St. John\'s Campus ,TLC in Home Care ,VistaCare Care Hospice ,West Texas Real Care').split(',').map(function (people) {
        //    return { abbrev: people };
        //});

        $scope.addEmergencyContact = function (event) {

            if ($scope.EmergencyContactAdd.addEMR_CON_1 != "") {

                var addEmergencyContact = {
                    "RecipientID": $scope.reci.RecipientID,
                    "EMR_CON_1": $scope.EmergencyContactAdd.addEMR_CON_1,
                    "EMR_CON1HM": $scope.EmergencyContactAdd.addEMR_CON1HM,
                    "EMR_CON1WK": $scope.EmergencyContactAdd.addEMR_CON1WK,
                    "EmergCellPhone": $scope.EmergencyContactAdd.addEmergCellPhone
                }

                recipientService.insertEmergency(addEmergencyContact).then(function (response) {
                    if (response.status == 200) {
                console.log(addEmergencyContact);

                $scope.EmergencyContactAdd.addEMR_CON_1 = "";
                $scope.EmergencyContactAdd.addEMR_CON1HM = "";
                $scope.EmergencyContactAdd.addEMR_CON1WK = "";
                $scope.EmergencyContactAdd.addEmergCellPhone = "";

                recipientService.getRecipient(id).then(onGetSuccess, onError);
                    }
                    else {
                        console.log("error: " + response);
                    }
                });

            }

            else {
                $scope.showEmergencyAlert(event);
            }

        }

        $scope.addNextOfKin = function (event) {

            if ($scope.NextOfKinAdd.addN_KIN_CITY != "") {

                var addNextOfKin = {
                    "RecipientID": $scope.reci.RecipientID,
                    "N_KIN_CITY": $scope.NextOfKinAdd.addN_KIN_CITY,
                    "NOK_HME_PH": $scope.NextOfKinAdd.addNOK_HME_PH,
                    "NOK_WRK_PH": $scope.NextOfKinAdd.addNOK_WRK_PH,
                    "NOKCellPhone": $scope.NextOfKinAdd.addNOKCellPhone,
                    "NOK_TYPE": $scope.NextOfKinAdd.addNOK_TYPE,
                    "NOK_ADDR_1": $scope.NextOfKinAdd.addNOK_ADDR_1,
                    "NOK_ADDR_2": $scope.NextOfKinAdd.addNOK_ADDR_2
                }

                recipientService.insertNok(addNextOfKin).then(function (response) {
                    if (response.status == 200) {
                console.log(addNextOfKin);

                $scope.NextOfKinAdd.addN_KIN_CITY = "";
                $scope.NextOfKinAdd.addNOK_HME_PH = "";
                $scope.NextOfKinAdd.addNOKCellPhone = "";
                $scope.NextOfKinAdd.addNOK_WRK_PH = "";
                $scope.NextOfKinAdd.addNOK_TYPE = "";
                $scope.NextOfKinAdd.addNOK_ADDR_1 = "";
                $scope.NextOfKinAdd.addNOK_ADDR_2 = "";

                recipientService.getRecipient(id).then(onGetSuccess, onError);
                    }
                    else {
                        console.log("error: " + response);
                    }
                });

            }

            else {
                $scope.showNexOfKinAlert(event);
            }

        }

        $scope.addComment = function (event) {

            if ($scope.CommentsAdd.addCommentDate != "" || $scope.CommentsAdd.addComment != "") {

                var addComment = {
                    "RecipientID": $scope.reci.RecipientID,
                    "Date": $scope.CommentsAdd.addCommentDate,
                    "COMMENTS": $scope.CommentsAdd.addComment,
                }

                commentService.insertComment(addComment).then(function (response) {
                    if (response.status == 200) {
                //console.log(addComment);

                $scope.CommentsAdd.addCommentDate = "";
                $scope.CommentsAdd.addComment = "";

                commentService.getComment(id).then(onCommentSuccess, onError);
                    }
                    else {
                        console.log("error: " + response);
                    }
                });

            }

            else {
                $scope.showCommentAlert(event);
            }

        }

        $scope.modEmergencyContact = function (EmergencyID) {

            for (var EmergencyContact in $scope.EmergencyContact) {
                if ($scope.EmergencyContact[EmergencyContact].EmergencyID == EmergencyID) {

                    var modEmergencyContact = {
                        "EmergencyID": $scope.EmergencyContact[EmergencyContact].EmergencyID,
                        "EMR_CON_1": $scope.EmergencyContact[EmergencyContact].EMR_CON_1,
                        "EMR_CON1HM": $scope.EmergencyContact[EmergencyContact].EMR_CON1HM,
                        "EMR_CON1WK": $scope.EmergencyContact[EmergencyContact].EMR_CON1WK,
                        "EmergCellPhone": $scope.EmergencyContact[EmergencyContact].EmergCellPhone
                    }

                    //console.log(modEmergencyContact);

                    recipientService.updateEmergency(modEmergencyContact).then(function (response) {
                        if (response.status == 200) {
                            //console.log(response);
                            recipientService.getRecipient(id).then(onGetSuccess, onError);
                        }
                        else {
                            console.log("error: " + response);
                        }
                    });
                }
            }
        }

        $scope.modNextOfKin = function (NextOfKinID) {

            for (var NextOfKin in $scope.NextOfKin) {
                if ($scope.NextOfKin[NextOfKin].NextOfKinID == NextOfKinID) {

                    var modNextOfKin = {
                        "NextOfKinID": $scope.NextOfKin[NextOfKin].NextOfKinID,
                        "N_KIN_CITY": $scope.NextOfKin[NextOfKin].N_KIN_CITY,
                        "NOK_HME_PH": $scope.NextOfKin[NextOfKin].NOK_HME_PH,
                        "NOK_WRK_PH": $scope.NextOfKin[NextOfKin].NOK_WRK_PH,
                        "NOKCellPhone": $scope.NextOfKin[NextOfKin].NOKCellPhone,
                        "NOK_TYPE": $scope.NextOfKin[NextOfKin].NOK_TYPE,
                        "NOK_ADDR_1": $scope.NextOfKin[NextOfKin].NOK_ADDR_1,
                        "NOK_ADDR_2": $scope.NextOfKin[NextOfKin].NOK_ADDR_2
                    }

                    //console.log(modNextOfKin);

                    recipientService.updateNok(modNextOfKin).then(function (response) {
                        if (response.status == 200) {
                            //console.log(response);
                            recipientService.getRecipient(id).then(onGetSuccess, onError);
                        }
                        else {
                            console.log("error: " + response);
                        }
                    });
                }
            }
        }

        $scope.modComment = function (CommentID) {

            for (var Comment in $scope.Comments) {
                if ($scope.Comments[Comment].CommentID == CommentID) {

                    var modComment = {
                        "CommentID": $scope.Comments[Comment].CommentID,
                        "Date": $scope.Comments[Comment].Date,
                        "COMMENTS": $scope.Comments[Comment].COMMENTS
                    }

                    //console.log(modNextOfKin);

                    commentService.updateComment(modComment).then(function (response) {
                        if (response.status == 200) {
                            //console.log(response);
                            commentService.getComment(id).then(onCommentSuccess, onError);
                        }
                        else {
                            console.log("error: " + response);
                        }
                    });
                }
            }
        }

        $scope.deleteEmergencyContact = function (EmergencyID) {
            //console.log("delete: " + EmergencyID);

            recipientService.deleteEmergency(EmergencyID).then(function (response) {
                if (response.status == 200) {
                    //console.log(response);
                    recipientService.getRecipient(id).then(onGetSuccess, onError);
                }
                else {
                    console.log("error: " + response);
                }
            });

            
        }

        $scope.deleteNextOfKin = function (NextOfKinID) {
            console.log("delete: " + NextOfKinID);

            recipientService.deleteNok(NextOfKinID).then(function (response) {
                if (response.status == 200) {
                    //console.log(response);
                    recipientService.getRecipient(id).then(onGetSuccess, onError);
                }
                else {
                    console.log("error: " + response);
                }
            });
        }

        $scope.deleteComment = function (CommentID) {
            //console.log("delete: " + CommentID);

            commentService.deleteComment(CommentID).then(function (response) {
                if (response.status == 200) {
                    //console.log(response);
                    commentService.getComment(id).then(onCommentSuccess, onError);
                }
                else {
                    console.log("error: " + response);
                }
            });
        }

        $scope.updateRecipient = function () {

            recipientService.updateRecipient($scope.reci).then(function (response) {

                console.log($scope.reci);

                if (response.status == 200) {
                    console.log(response);
                    recipientService.getRecipient(id).then(onGetSuccess, onError);
                }
                else {
                    recipientService.getRecipient(id).then(onGetSuccess, onError);
                    console.log("error: " + response);
                }
            });

        }

        $scope.showDeleteConfirm = function (ev) {
            // Appending dialog to document.body to cover sidenav in docs app
            var confirm = $mdDialog.confirm()
                .title('Delete Recipient?')
                .textContent('Would you like to delete recipient ' + $scope.reci.RecipientID + ' ' + $scope.reci.FIRST_NAME)
                .ariaLabel('Delete')
                .targetEvent(ev)
                .ok('Delete')
                .cancel('Cancel');

            $mdDialog.show(confirm).then(function () {
                console.log($scope.reci.RecipientID + " has been deleted.");
            }, function () {
                console.log($scope.reci.RecipientID + " has not been deleted.");
            });
        };

        $scope.showEmergencyAlert = function (ev) {
            // Appending dialog to document.body to cover sidenav in docs app
            // Modal dialogs should fully cover application
            // to prevent interaction outside of dialog
            $mdDialog.show(
                $mdDialog.alert()
                    .parent(angular.element(document.querySelector('#popupContainer')))
                    .clickOutsideToClose(true)
                    .title('Missing Field')
                    .textContent('You are missing the Emergency Contacts Name Field.')
                    .ariaLabel('Alert Dialog')
                    .ok('ok')
                    .targetEvent(ev)
            );
        };

        $scope.showNexOfKinAlert = function (ev) {
            // Appending dialog to document.body to cover sidenav in docs app
            // Modal dialogs should fully cover application
            // to prevent interaction outside of dialog
            $mdDialog.show(
                $mdDialog.alert()
                    .parent(angular.element(document.querySelector('#popupContainer')))
                    .clickOutsideToClose(true)
                    .title('Missing Field')
                    .textContent('You are missing the Next of Kin Name Field.')
                    .ariaLabel('Alert Dialog')
                    .ok('ok')
                    .targetEvent(ev)
            );
        };

        $scope.showCommentAlert = function (ev) {
            // Appending dialog to document.body to cover sidenav in docs app
            // Modal dialogs should fully cover application
            // to prevent interaction outside of dialog
            $mdDialog.show(
                $mdDialog.alert()
                    .parent(angular.element(document.querySelector('#popupContainer')))
                    .clickOutsideToClose(true)
                    .title('Missing Field')
                    .textContent('You are missing the Comment Date or Comment')
                    .ariaLabel('Alert Dialog')
                    .ok('ok')
                    .targetEvent(ev)
            );
        };


        function int() {

        }

        var onGetSuccess = function (response) {
            $scope.reci = response.data[0];

            $scope.NextOfKin = response.data[1];
            $scope.EmergencyContact = response.data[2];

            //$scope.reci.Date1stOn = new Date($scope.reci.Date1stOn);
            //$scope.reci.Date_Start = new Date($scope.reci.Date_Start);
            //$scope.reci.ModificationDate = new Date($scope.reci.ModificationDate);
            //$scope.reci.Date_Off = new Date($scope.reci.Date_Off);
            //$scope.reci.BIRTH_DATE = new Date($scope.reci.BIRTH_DATE);

            if ($scope.reci.Date1stOn == "" || $scope.reci.Date1stOn == null) {

            }
            else {
                $scope.reci.Date1stOn = new Date($scope.reci.Date1stOn);
            }

            if ($scope.reci.Date_Start == "" || $scope.reci.Date_Start == null) {

            }
            else {
                $scope.reci.Date_Start = new Date($scope.reci.Date_Start);
            }

            if ($scope.reci.ModificationDate == "" || $scope.reci.ModificationDate == null) {

            }
            else {
                $scope.reci.ModificationDate = new Date($scope.reci.ModificationDate);
            }

            if ($scope.reci.Date_Off == "" || $scope.reci.Date_Off == null) {

            }
            else {
                $scope.reci.Date_Off = new Date($scope.reci.Date_Off);
            }

            if ($scope.reci.BIRTH_DATE == "" || $scope.reci.BIRTH_DATE == null) {

            }
            else {
                $scope.reci.BIRTH_DATE = new Date($scope.reci.BIRTH_DATE);
            }


            if ($scope.reci.Home_Visit_Date == "" || $scope.reci.Home_Visit_Date == null){

            }
            else {
                $scope.reci.Home_Visit_Date = new Date($scope.reci.Home_Visit_Date);
            }

            if ($scope.reci.Fan_Delivered == "" || $scope.reci.Fan_Delivered == null) {

            }
            else {
                $scope.reci.Fan_Delivered = new Date($scope.reci.Fan_Delivered);
            }

            $scope.reci.ROUTE_SEQ = parseFloat($scope.reci.ROUTE_SEQ);
            //$scope.reci.SpouseRecipientNum = parseFloat($scope.reci.SpouseRecipientNum);




            //console.log($scope.reci.DEL_INST);

            //console.log($scope);

        }

        var onError = function (reason) {
            $log.info(reason);
        }

        int();

        var onRouteSuccess = function (response) {
            $scope.routes = response.data;
        }

        function dateConvert() {
            for (var Comment in $scope.Comments) {
                //console.log($scope.Comments[Comment]);
                $scope.Comments[Comment].Date = new Date($scope.Comments[Comment].Date);
            }
            return Comment;
        }

        var onCommentSuccess = function (response) {


            $scope.Comments = response.data;
            dateConvert();
            //console.log($scope.Comments);
        }


        var onRefferedBySuccess = function (response) {
            $scope.refferedBy = response.data;
            //console.log(response.data);
        }

        recipientService.getRecipient(id).then(onGetSuccess, onError);
        miscService.getRoute().then(onRouteSuccess, onError);
        miscService.getRefferedBy().then(onRefferedBySuccess, onError);
        commentService.getComment(id).then(onCommentSuccess, onError);




    };
    app.controller("Recipient", Recipient);
})();