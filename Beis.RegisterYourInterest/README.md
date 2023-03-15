The CSS is compiled automatically on build. To setup the CSS manually run the following commands:

Run npm Install
npm run build
npm run watch


In order for this to work you will need to add the following users secrets via the user secret manager:

{
	  
  "REDIS_PRIMARY_CONNECTION_STRING": "",
  "CONNECTIONSTRING": "",
  "AZURE_MONITOR_INSTRUMENTATION_KEY": "",


}

Additional secrets that may be needed if installing additiona feature are :

{
    "PayPoint": {
    "BaseAddress": "https://multipay-sandbox.azure-api.net/",
    "ApiKey": "",
    "SubscriptionKey": ""
  },

  "OSPlacesAPI": {
    "ApiKey": "",
    "ApiSecret": ""
  }
}

