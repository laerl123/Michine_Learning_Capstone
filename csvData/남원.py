import pandas as pd
import numpy as np
from sklearn.linear_model import LinearRegression
from sklearn.preprocessing import MinMaxScaler
import matplotlib.pyplot as plt

traffic = pd.read_csv("남원_202011부터_202104_빈데이터제거.csv")

normalization = traffic / traffic.max()


X = normalization[['순창IC-남원JC교통량']]
y = traffic[['순창IC-남원JC평균속도']]


model = LinearRegression()
model.fit(X, y)


plt.scatter(X, y)
plt.show()

print("순창IC-남원JC")
print("y=",model.coef_,"x +",model.intercept_)



X = normalization[['남원JC-남원IC교통량']]
y = traffic[['남원JC-남원IC평균속도']]


model = LinearRegression()
model.fit(X, y)


plt.scatter(X, y)
plt.show()

print("남원JC-남원IC")
print("y=",model.coef_,"x +",model.intercept_)




X = normalization[['남원JC-순창IC교통량']]
y = traffic[['남원JC-순창IC평균속도']]


model = LinearRegression()
model.fit(X, y)


plt.scatter(X, y)
plt.show()

print("남원JC-순창IC")
print("y=",model.coef_,"x +",model.intercept_)




X = normalization[['남원IC-남원JC교통량']]
y = traffic[['남원IC-남원JC평균속도']]


model = LinearRegression()
model.fit(X, y)


plt.scatter(X, y)
plt.show()

print("남원IC-남원JC")
print("y=",model.coef_,"x +",model.intercept_)




X = normalization[['서남원IC-남원JC교통량']]
y = traffic[['서남원IC-남원JC평균속도']]


model = LinearRegression()
model.fit(X, y)


plt.scatter(X, y)
plt.show()

print("서남원IC-남원JC")
print("y=",model.coef_,"x +",model.intercept_)




X = normalization[['남원JC-북남원IC교통량']]
y = traffic[['남원JC-북남원IC평균속도']]


model = LinearRegression()
model.fit(X, y)


plt.scatter(X, y)
plt.show()

print("남원JC-북남원IC")
print("y=",model.coef_,"x +",model.intercept_)




X = normalization[['남원JC-서남원IC교통량']]
y = traffic[['남원JC-서남원IC평균속도']]


model = LinearRegression()
model.fit(X, y)


plt.scatter(X, y)
plt.show()

print("남원JC-서남원IC")
print("y=",model.coef_,"x +",model.intercept_)




X = normalization[['북남원IC-남원JC교통량']]
y = traffic[['북남원IC-남원JC평균속도']]


model = LinearRegression()
model.fit(X, y)


plt.scatter(X, y)
plt.show()

print("북남원IC-남원JC")
print("y=",model.coef_,"x +",model.intercept_)
