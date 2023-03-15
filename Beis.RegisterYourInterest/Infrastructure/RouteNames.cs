using Beis.Common.Constants;

namespace Beis.RegisterYourInterest.Infrastructure
{
    public static class RouteNames
    {
        public const string HomePage = "HomePage";
        public const string Heartbeat = "Heartbeat";
        public const string PrivacyPage = "Privacy";
        public const string AccessibilityStatementPage = "AccessibilityStatement";
        public const string CookiesPage = "cookies";
        public const string CookieSettingsPage = "CookieSettingsPage";
        public const string SessionExpiredPage = "SessionExpiredPage";
        public const string HasCompaniesHousePage = "HasCompaniesHousePage";
        public const string CompaniesHouseNumberPage = "CompaniesHouseNumberPage";
        public const string ConfirmCompaniesHouseDetailsPage = "ConfirmCompaniesHouseDetailsPage";
        public const string CompaniesHouseServiceUnavailable = "CompaniesHouseServiceUnavailable";

        public const string HasFcaNumberPage = "HasFcaNumberPage";
        public const string FcaNumberPage = "FcaNumberPage";
        public const string FcaNumberNotFoundPage = "FcaNumberNotFoundPage";
        public const string FcaNumberDeregisteredPage = "FcaNumberDeregisteredPage";
        public const string ConfirmFcaDetailsPage = "ConfirmFcaDetailsPage";
        public const string IneligiblePage = "IneligiblePage";

        public const string ApplicantFullNamePage = "ApplicantFullNamePage";
        public const string ApplicantPhoneNumberPage = "ApplicantPhoneNumberPage";
        public const string ApplicantRolePage = "ApplicantRolePage";
        public const string ApplicantEmailAddressPage = "ApplicantEmailAddressPage";
        public const string ConfirmEmailAddressPage = "ConfirmEmailAddressPage";
        public const string VerifyEmailAddressPage  = "VerifyEmailAddressPage"; 

        public const string ThankYouForYourInterestPage = "ThankYouForYourInterestPage";



    }

    public static class RoutePaths
    {
        public const string HomePage = "/";
        public const string Heartbeat = "heartbeat";
        public const string PrivacyPage = "privacy";
        public const string AccessibilityStatementPage = "accessibility-statement";
        public const string CookiesPage = "cookies";
        public const string CookieSettingsPage = "home/cookies";
        public const string SessionExpiredPage = "session-expired";
        public const string HasCompaniesHousePage = "do-you-have-a-companies-house-number";
        public const string CompaniesHouseNumberPage = "what-is-your-companies-house-number";
        public const string ConfirmCompaniesHouseDetailsPage = "confirm-companies-house-details";
        public const string CompaniesHouseServiceUnavailable = "companies-huse-srvice-unavailable";

        public const string HasFcaNumberPage = "do-you-have-an-fca-number";
        public const string FcaNumberPage = "what-is-your-fca-number";
        public const string FcaNumberNotFoundPage = "fca-number-not-found";
        public const string FcaNumberDeregisteredPage = "fca-deregistered";
        public const string ConfirmFcaDetailsPage = "confirm-fca-details";
        public const string IneligiblePage = "ineligible";

        public const string ApplicantFullNamePage = "what-is-your-full-name";
        public const string ApplicantPhoneNumberPage = "what-is-your-phone-number";
        public const string ApplicantRolePage = "what-is-your-role";
        public const string ApplicantEmailAddressPage = "what-is-your-email-address";
        public const string ConfirmEmailAddressPage = "confirm-your-email-address";
        public const string VerifyEmailAddressPage = CommonConstants.VerifyEmailAddressPath;

        public const string ThankYouForYourInterestPage = "thank-you-for-your-interest";
    }

    public static class RoutePathNameMap
    {
        public static Dictionary<string, string> Lookup = new()
        {
            {string.Empty, RouteNames.HomePage },
        };
    }
}