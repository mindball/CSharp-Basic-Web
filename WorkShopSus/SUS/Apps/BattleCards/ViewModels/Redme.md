# Best practice case with many parameters in methods:
## break the method into multiple methods, each which require only a subset of the parameters
## create helper classes to hold group of parameters (typically static member classes)
## adapt the Builder pattern from object construction to method invocation.