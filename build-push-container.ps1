param (
    [string]$prefix = "ben2code", 
    [string]$tag = "latest"
    )

$builddate = "2021-07-31"
$buildversion = "1.1"


$container = "pubsubapi"
$latest = "{0}/{1}:{2}" -f $prefix, $container, $tag 
$versioned = "{0}/{1}:{2}" -f $prefix, $container, $buildversion
docker build . -f .\pubsubapi\Dockerfile -t $latest -t $versioned --build-arg BUILD_DATE=$builddate --build-arg BUILD_VERSION=$buildversion
docker push $versioned
docker push $latest 

$container = "pubsubmvcsample"
$latest = "{0}/{1}:{2}" -f $prefix, $container, $tag 
$versioned = "{0}/{1}:{2}" -f $prefix, $container, $buildversion
docker build . -f .\pubsubmvcsample\Dockerfile -t $latest -t $versioned --build-arg BUILD_DATE=$builddate --build-arg BUILD_VERSION=$buildversion
docker push $versioned
docker push $latest 