start dapr run --app-id pubsubmvcsample --app-port 5002  --dapr-http-port 50002 --components-path "./componments" -- dotnet run --project "./pubsubmvcsample/pubsubmvcsample.csproj"

start dapr run --app-id pubsubapi --app-port 5003  --dapr-http-port 50003 --components-path "./componments" -- dotnet run --project "./pubsubapi/pubsubapi.csproj"
