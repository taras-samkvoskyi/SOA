
// This ViewModel demonstrates SPA-Wizards & per-step validation

(function (cr) {
    var AccountRegisterViewModel = function () {

        var self = this;

        var initialState = 'register'; // represents the first view mode - in other VMs, can come through an argument

        self.viewModelHelper = new CarRental.viewModelHelper();
        self.accountModelStep1 = ko.observable();
        self.accountModelStep2 = ko.observable();
        self.accountModelStep3 = ko.observable();
        self.viewMode = ko.observable(); // register1, register2, register3, confirm, welcome

        self.initialize = function () {
            self.accountModelStep1(new CarRental.AccountRegisterModelStep1());
            self.accountModelStep2(new CarRental.AccountRegisterModelStep2());
            self.accountModelStep3(new CarRental.AccountRegisterModelStep3());
            self.viewMode('register1'); // this will perform the first url-state handling round
        }

        self.nextStep = function (model) {
            var unmappedModel = ko.mapping.toJS(model);
            if (self.viewMode() == 'register1') {
                var valModel = { val: self.accountModelStep1 };
                var errors = ko.validation.group(valModel, { deep: true });
                self.viewModelHelper.modelIsValid(valModel.isValid());
                if (errors().length == 0) {
                    self.viewModelHelper.apiPost('api/account/register/validate1', unmappedModel,
                        function (result) {
                            self.viewMode('register2');
                        });
                }
                else
                    self.viewModelHelper.modelErrors(errors());
            }
            else if (self.viewMode() == 'register2') {
                var valModel = { val: self.accountModelStep2 };
                var errors = ko.validation.group(valModel, { deep: true });
                self.viewModelHelper.modelIsValid(valModel.isValid());
                if (errors().length == 0) {
                    self.viewModelHelper.apiPost('api/account/register/validate2', unmappedModel,
                    function (result) {
                        self.viewMode('register3');
                    });
                }
                else
                    self.viewModelHelper.modelErrors(errors());
            }
            else if (self.viewMode() == 'register3') {
                var valModel = { val: self.accountModelStep3  };
                var errors = ko.validation.group(valModel, { deep: true });
                self.viewModelHelper.modelIsValid(valModel.isValid());
                if (errors().length == 0) {
                    self.viewModelHelper.apiPost('api/account/register/validate3', unmappedModel,
                    function (result) {
                        self.viewMode('confirm');
                    });
                }
                else
                    self.viewModelHelper.modelErrors(errors());
            }
        }

        self.prevStep = function (model) {
            self.viewModelHelper.modelIsValid(true);
            if (self.viewMode() == 'register2') {
                self.viewMode('register1');
            }
            else if (self.viewMode() == 'register3') {
                self.viewMode('register2');
            }
            else if (self.viewMode() == 'confirm') {
                self.viewMode('register3');
            }
        }

        self.createAccount = function (model) {
            var unmappedModel;

            var step1Unmapped = ko.mapping.toJS(self.accountModelStep1);
            var step2Unmapped = ko.mapping.toJS(self.accountModelStep2);
            var step3Unmapped = ko.mapping.toJS(self.accountModelStep3);

            unmappedModel = $.extend(unmappedModel, step1Unmapped);
            unmappedModel = $.extend(unmappedModel, step2Unmapped);
            unmappedModel = $.extend(unmappedModel, step3Unmapped);

            self.viewModelHelper.apiPost('api/account/register', unmappedModel,
                function (result) {
                    self.viewMode('welcome');
                });
        }

        self.viewMode.subscribe(function () {
            self.viewModelHelper.pushUrlState(self.viewMode(), null, null, 'account/register');
            initialState = self.viewModelHelper.handleUrlState(initialState);
        });        

        if (Modernizr.history) {
            window.onpopstate = function (arg) {
                if (arg.state != null) {
                    self.viewModelHelper.statePopped = true;
                    self.viewMode(arg.state.Code);
                }
            };
        }

        self.initialize();
    }
    cr.AccountRegisterViewModel = AccountRegisterViewModel;
}(window.CarRental));
