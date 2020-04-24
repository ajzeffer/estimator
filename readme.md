# Estimator
This console app can be installed as a global tool using the following command
```
dotnet tool install --global --add-source ./nupkg estimator
```

once that has succesfully installed you can call
```
esimate 2 weeks
```
and the tool will respond with a tshirt size LOE

## Tshirt Sizes
Tshirt sizes are currently hardcoded but we could extend this to check for an app setting

Current hard coded values

XS   < 1 week
S    - 1-2 weeks
M    - 2-4 weeks
L    - 4-8 weeks
XL   - 8+ weeks
XXL  - 3+ months
XXXL - 6+ months
