import pandas as pd
df = pd.read_csv("남원_202011부터_202104_빈데이터제거_교통량만_T버전.csv")
from sklearn.model_selection import train_test_split

x = df[['T12_2','T10_2', 'T11']]
y = df[['T1_2']]

x_train, x_test, y_train, y_test = train_test_split(x, y, train_size=0.8, test_size=0.2)

from sklearn.linear_model import LinearRegression
mlr = LinearRegression()
mlr.fit(x_train, y_train)

y_predict = mlr.predict(x_test)

import matplotlib.pyplot as plt
plt.scatter(y_test, y_predict, alpha=0.4)
plt.show()

print("진출도로 y = 영향을 끼치는 3개의 진입도로 x \n")
print("기울기")
print(mlr.coef_)
print("상수")
print(mlr.intercept_)
print("정확도")
print(mlr.score(x_train, y_train))
print("비례식")
print("T1_2 =",round(mlr.intercept_[0],2),"+",round(mlr.coef_[0][0],2),"T12_2 +",round(mlr.coef_[0][1],2),"T10_2 +",round(mlr.coef_[0][2],2),"T11")
print("\n")






x = df[['T11','T10_2', 'T1']]
y = df[['T12']]

x_train, x_test, y_train, y_test = train_test_split(x, y, train_size=0.8, test_size=0.2)

from sklearn.linear_model import LinearRegression
mlr = LinearRegression()
mlr.fit(x_train, y_train)

y_predict = mlr.predict(x_test)

import matplotlib.pyplot as plt
plt.scatter(y_test, y_predict, alpha=0.4)
plt.show()

print("기울기")
print(mlr.coef_)
print("상수")
print(mlr.intercept_)
print("정확도")
print(mlr.score(x_train, y_train))
print("비례식")
print("T12 =",round(mlr.intercept_[0],2),"+",round(mlr.coef_[0][0],2),"T11 +",round(mlr.coef_[0][1],2),"T10_2 +",round(mlr.coef_[0][2],2),"T1")
print("\n")




x = df[['T12_2','T11', 'T1']]
y = df[['T10']]

x_train, x_test, y_train, y_test = train_test_split(x, y, train_size=0.8, test_size=0.2)

from sklearn.linear_model import LinearRegression
mlr = LinearRegression()
mlr.fit(x_train, y_train)

y_predict = mlr.predict(x_test)

import matplotlib.pyplot as plt
plt.scatter(y_test, y_predict, alpha=0.4)
plt.show()

print("기울기")
print(mlr.coef_)
print("상수")
print(mlr.intercept_)
print("정확도")
print(mlr.score(x_train, y_train))
print("비례식")
print("T10 =",round(mlr.intercept_[0],2),"+",round(mlr.coef_[0][0],2),"T12_2 +",round(mlr.coef_[0][1],2),"T11 +",round(mlr.coef_[0][2],2),"T1")
print("\n")





x = df[['T12_2','T1', 'T10_2']]
y = df[['T11_2']]

x_train, x_test, y_train, y_test = train_test_split(x, y, train_size=0.8, test_size=0.2)

from sklearn.linear_model import LinearRegression
mlr = LinearRegression()
mlr.fit(x_train, y_train)

y_predict = mlr.predict(x_test)

import matplotlib.pyplot as plt
plt.scatter(y_test, y_predict, alpha=0.4)
plt.show()

print("기울기")
print(mlr.coef_)
print("상수")
print(mlr.intercept_)
print("정확도")
print(mlr.score(x_train, y_train))
print("비례식")
print("T11_2 =",round(mlr.intercept_[0],2),"+",round(mlr.coef_[0][0],2),"T12_2 +",round(mlr.coef_[0][1],2),"T1 +",round(mlr.coef_[0][2],2),"T10_2")
print("\n")

