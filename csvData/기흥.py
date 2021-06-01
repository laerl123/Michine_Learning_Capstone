import pandas as pd
import numpy as np
from sklearn.linear_model import LinearRegression
from sklearn.preprocessing import MinMaxScaler
import matplotlib.pyplot as plt

traffic = pd.read_csv("수원신갈_기흥_2020년_7월부터_12월_교통량속도.csv")

normalization = traffic / traffic.max()

X = normalization[['교통량']]
y = traffic[['평균속도']]

model = LinearRegression()
model.fit(X, y)


plt.scatter(X, y)
plt.show()

print("수원신갈-기흥")
#print("기울기 = ",model.coef_)
#print("y절편 = ",model.intercept_)
print("y=",model.coef_,"x +",model.intercept_)




traffic = pd.read_csv("기흥_기흥동탄_2020년_7월부터_12월_교통량속도.csv")

normalization = traffic / traffic.max()

X = normalization[['교통량']]
y = traffic[['평균속도']]

model = LinearRegression()
model.fit(X, y)


plt.scatter(X, y)
plt.show()

print("기흥-기흥동탄")
#print("기울기 = ",model.coef_)
#print("y절편 = ",model.intercept_)
print("y=",model.coef_,"x +",model.intercept_)




traffic = pd.read_csv("Re기흥동탄_동탄_2020년_7월부터_12월_교통량속도.csv")

normalization = traffic / traffic.max()

X = normalization[['교통량']]
y = traffic[['평균속도']]

model = LinearRegression()
model.fit(X, y)


plt.scatter(X, y)
plt.show()

print("기흥동탄-동탄")
#print("기울기 = ",model.coef_)
#print("y절편 = ",model.intercept_)
print("y=",model.coef_,"x +",model.intercept_)

