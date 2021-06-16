import pandas as pd
df = pd.read_csv("남원_202011부터_202104_빈데이터제거_교통량만_T버전.csv")
from sklearn.model_selection import train_test_split

my_list = [['y1상수','y1계수1','y1계수2','y1계수3'],['y2상수','y2계수1','y2계수2','y2계수3'],['y3상수','y3계수1','y3계수2','y3계수3'],['y4상수','y4계수1','y4계수2','y4계수3']]
x = df[['T12_2','T10_2', 'T11']]
y = df[['T1_2']]

x_train, x_test, y_train, y_test = train_test_split(x, y, train_size=0.8, test_size=0.2)

from sklearn.linear_model import LinearRegression
mlr = LinearRegression()
mlr.fit(x_train, y_train)

y_predict = mlr.predict(x_test)

import matplotlib.pyplot as plt
plt.scatter(y_test, y_predict, alpha=0.4)

print("진출도로 y = 영향을 끼치는 3개의 진입도로 x \n")
print("기울기")
print(mlr.coef_)
print("상수")
print(mlr.intercept_)
print("정확도")
print(mlr.score(x_train, y_train))
print("비례식")
print("y3.T1_2 =",round(mlr.intercept_[0],2),"+",round(mlr.coef_[0][2],2),"x2(T11) + ",round(mlr.coef_[0][1],2),"x3(T10_2) +",round(mlr.coef_[0][0],2),"x4(T12_2)")
print("\n")

my_list[2][0]=mlr.intercept_[0]
my_list[2][1]=mlr.coef_[0][2]
my_list[2][2]=mlr.coef_[0][1]
my_list[2][3]=mlr.coef_[0][0]




x = df[['T11','T10_2', 'T1']]
y = df[['T12']]

x_train, x_test, y_train, y_test = train_test_split(x, y, train_size=0.8, test_size=0.2)

from sklearn.linear_model import LinearRegression
mlr = LinearRegression()
mlr.fit(x_train, y_train)

y_predict = mlr.predict(x_test)

import matplotlib.pyplot as plt
plt.scatter(y_test, y_predict, alpha=0.4)

print("기울기")
print(mlr.coef_)
print("상수")
print(mlr.intercept_)
print("정확도")
print(mlr.score(x_train, y_train))
print("비례식")
print("y2.T12 =",round(mlr.intercept_[0],2),"+",round(mlr.coef_[0][2],2),"x1(T1) + ",round(mlr.coef_[0][0],2),"x2(T11) +",round(mlr.coef_[0][1],2),"x3(T10_2)")
print("\n")

my_list[1][0]=mlr.intercept_[0]
my_list[1][1]=mlr.coef_[0][2]
my_list[1][2]=mlr.coef_[0][0]
my_list[1][3]=mlr.coef_[0][1]




x = df[['T12_2','T11', 'T1']]
y = df[['T10']]

x_train, x_test, y_train, y_test = train_test_split(x, y, train_size=0.8, test_size=0.2)

from sklearn.linear_model import LinearRegression
mlr = LinearRegression()
mlr.fit(x_train, y_train)

y_predict = mlr.predict(x_test)

import matplotlib.pyplot as plt
plt.scatter(y_test, y_predict, alpha=0.4)

print("기울기")
print(mlr.coef_)
print("상수")
print(mlr.intercept_)
print("정확도")
print(mlr.score(x_train, y_train))
print("비례식")
print("y1.T10 =",round(mlr.intercept_[0],2),"+",round(mlr.coef_[0][2],2),"x1(T1) + ",round(mlr.coef_[0][1],2),"x2(T11) +",round(mlr.coef_[0][0],2),"x4(T12_2) +")
print("\n")

my_list[0][0]=mlr.intercept_[0]
my_list[0][1]=mlr.coef_[0][2]
my_list[0][2]=mlr.coef_[0][1]
my_list[0][3]=mlr.coef_[0][0]



x = df[['T12_2','T1', 'T10_2']]
y = df[['T11_2']]

x_train, x_test, y_train, y_test = train_test_split(x, y, train_size=0.8, test_size=0.2)

from sklearn.linear_model import LinearRegression
mlr = LinearRegression()
mlr.fit(x_train, y_train)

y_predict = mlr.predict(x_test)

import matplotlib.pyplot as plt
plt.scatter(y_test, y_predict, alpha=0.4)

print("기울기")
print(mlr.coef_)
print("상수")
print(mlr.intercept_)
print("정확도")
print(mlr.score(x_train, y_train))
print("비례식")
print("y4.T11_2 =",round(mlr.intercept_[0],2),"+",round(mlr.coef_[0][1],2),"x1(T1) +",round(mlr.coef_[0][2],2),"x3(T10_2) + ",round(mlr.coef_[0][0],2),"x4(T12_2)")
print("\n")

my_list[3][0]=mlr.intercept_[0]
my_list[3][1]=mlr.coef_[0][1]
my_list[3][2]=mlr.coef_[0][2]
my_list[3][3]=mlr.coef_[0][0]


dataframe = pd.DataFrame(my_list)
dataframe.to_csv("남원_다중선형회귀_계수.csv",header=False, index=False)




