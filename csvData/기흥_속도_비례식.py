import pandas as pd
import numpy as np
from sklearn.linear_model import LinearRegression
from sklearn.preprocessing import MinMaxScaler
import matplotlib.pyplot as plt

my_list=[['T1기울기','T1계수','T1최대교통량'],['T3기울기','T3계수','T3최대교통량'],['T5기울기','T5계수','T5최대교통량']]

traffic = pd.read_csv("수원신갈_기흥_2020년_7월부터_12월_교통량속도.csv")

X = MinMaxScaler().fit_transform(traffic[['교통량']])
y = traffic[['평균속도']]

model = LinearRegression()
model.fit(X, y)

print("수원신갈-기흥 2020년 7월부터 12월")
print("y=",model.coef_,"x +",model.intercept_)

my_list[0][0]= model.coef_[0][0]
my_list[0][1]= model.intercept_[0]
my_list[0][2]= int(traffic.max()['교통량'])





traffic = pd.read_csv("기흥_기흥동탄_2020년_7월부터_12월_교통량속도.csv")

X = MinMaxScaler().fit_transform(traffic[['교통량']])
y = traffic[['평균속도']]

model = LinearRegression()
model.fit(X, y)

print("기흥-기흥동탄 2020년 7월부터 12월")
print("y=",model.coef_,"x +",model.intercept_)

my_list[1][0]= model.coef_[0][0]
my_list[1][1]= model.intercept_[0]
my_list[1][2]= int(traffic.max()['교통량'])







traffic = pd.read_csv("Re기흥동탄_동탄_2020년_7월부터_12월_교통량속도.csv")

X = MinMaxScaler().fit_transform(traffic[['교통량']])
y = traffic[['평균속도']]

model = LinearRegression()
model.fit(X, y)

print("기흥동탄-동탄 2020년 7월부터 12월")
print("y=",model.coef_,"x +",model.intercept_)

my_list[2][0]= model.coef_[0][0]
my_list[2][1]= model.intercept_[0]
my_list[2][2]= int(traffic.max()['교통량'])





dataframe = pd.DataFrame(my_list)
dataframe.to_csv("기흥_속도_비례식계수.csv",header=False, index=False)




