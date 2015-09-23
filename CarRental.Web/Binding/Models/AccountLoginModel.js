
(function (cr) {
    var AccountLoginModel = function () {

        var self = this;

        self.LoginEmail = ko.observable("").extend({
            required: { message: "Login email is required" },
            email: { message: "Login is not a valid email" }
        });
        self.Password = ko.observable("").extend({
            required: { message: "Password is required" },
            minLength: { message: "Password must be at least 6 characters", params: 6 }
        });
        self.RememberMe = ko.observable(false);
    }
    cr.AccountLoginModel = AccountLoginModel;
}(window.CarRental));
