
(function (cr) {
    var MyAccountViewModel = function () {

        var self = this;

        self.viewModelHelper = new CarRental.viewModelHelper();
        self.viewMode = ko.observable(); // account, success
        self.accountModel = ko.observable();

        self.initialize = function () {
            self.viewModelHelper.apiGet('api/customer/account', null,
                function (result) {
                    self.accountModel(new CarRental.MyAccountModel(result.AccountId, result.LoginEmail,
                                                                   result.FirstName, result.LastName,
                                                                   result.Address, result.City, result.State, 
                                                                   result.ZipCode, result.CreditCard, result.ExpDate));
                    self.viewMode('account');
                });
        }

        self.save = function (model) {
            var errors = ko.validation.group(model, { deep: true });
            self.viewModelHelper.modelIsValid(model.isValid());
            if (errors().length == 0) {
                var unmappedModel = ko.mapping.toJS(model);
                self.viewModelHelper.apiPost('api/customer/account', unmappedModel,
                    function (result) {
                        self.viewMode('success');
                    });
            }
            else
                self.viewModelHelper.modelErrors(errors());
        }

        self.initialize();
    }
    cr.MyAccountViewModel = MyAccountViewModel;
}(window.CarRental));
