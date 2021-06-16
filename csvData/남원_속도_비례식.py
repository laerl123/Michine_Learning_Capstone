import pandas as pd
import numpy as np
from sklearn.linear_model import LinearRegression
from sklearn.preprocessing import MinMaxScaler
import matplotlib.pyplot as plt
import csv

my_list=[['x1기울기','x1계수','x1최대교통량'],['x2','x2','x2'],['x3','x3','x3'],['x4','x4','x4'],['y1','y1','y1'],['y2','y2','y2'],['y3','y3','y3'],['y4','y4','y4']]
traffic = pd.read_csv("남원_202011부터_202104_빈데이터제거.csv")

normalization = traffic / traffic.max()


X = normalization[['순창IC-남원JC교통량']]
y = traffic[['순창IC-남원JC평균속도']]


model = LinearRegression()
model.fit(X, y)

print("남원 속도 비례식 정리. x는 0~1사이의 혼잡도\n\n")

print("x4.T12_2(순창IC-남원JC)")
print("y=",round(model.coef_[0][0],2),"x +",round(model.intercept_[0],2))
print("교통량 최대값 = ",int(traffic.max()['순창IC-남원JC교통량']),"\n")

my_list[3][0]= model.coef_[0][0]
my_list[3][1]= model.intercept_[0]
my_list[3][2]= int(traffic.max()['순창IC-남원JC교통량'])




X = normalization[['남원JC-남원IC교통량']]
y = traffic[['남원JC-남원IC평균속도']]


model = LinearRegression()
model.fit(X, y)

print("y4.T11_2(남원JC-남원IC)")
print("y=",round(model.coef_[0][0],2),"x +",round(model.intercept_[0],2))
print("교통량 최대값 = ",int(traffic.max()['남원JC-남원IC교통량']),"\n")

my_list[7][0]= model.coef_[0][0]
my_list[7][1]= model.intercept_[0]
my_list[7][2]= int(traffic.max()['남원JC-남원IC교통량'])



X = normalization[['남원JC-순창IC교통량']]
y = traffic[['남원JC-순창IC평균속도']]


model = LinearRegression()
model.fit(X, y)

print("y2.T12(남원JC-순창IC)")
print("y=",round(model.coef_[0][0],2),"x +",round(model.intercept_[0],2))
print("교통량 최대값 = ",int(traffic.max()['남원JC-순창IC교통량']),"\n")

my_list[5][0]= model.coef_[0][0]
my_list[5][1]= model.intercept_[0]
my_list[5][2]= int(traffic.max()['남원JC-순창IC교통량'])



X = normalization[['남원IC-남원JC교통량']]
y = traffic[['남원IC-남원JC평균속도']]


model = LinearRegression()
model.fit(X, y)

print("x2.T11(남원IC-남원JC)")
print("y=",round(model.coef_[0][0],2),"x +",round(model.intercept_[0],2))
print("교통량 최대값 = ",int(traffic.max()['남원IC-남원JC교통량']),"\n")

my_list[1][0]= model.coef_[0][0]
my_list[1][1]= model.intercept_[0]
my_list[1][2]= int(traffic.max()['남원IC-남원JC교통량'])




X = normalization[['서남원IC-남원JC교통량']]
y = traffic[['서남원IC-남원JC평균속도']]


model = LinearRegression()
model.fit(X, y)

print("x3.T10_2(서남원IC-남원JC)")
print("y=",round(model.coef_[0][0],2),"x +",round(model.intercept_[0],2))
print("교통량 최대값 = ",int(traffic.max()['서남원IC-남원JC교통량']),"\n")

my_list[2][0]= model.coef_[0][0]
my_list[2][1]= model.intercept_[0]
my_list[2][2]= int(traffic.max()['서남원IC-남원JC교통량'])



X = normalization[['남원JC-북남원IC교통량']]
y = traffic[['남원JC-북남원IC평균속도']]


model = LinearRegression()
model.fit(X, y)

print("y3.T1_2(남원JC-북남원IC)")
print("y=",round(model.coef_[0][0],2),"x +",round(model.intercept_[0],2))
print("교통량 최대값 = ",int(traffic.max()['남원JC-북남원IC교통량']),"\n")

my_list[6][0]= model.coef_[0][0]
my_list[6][1]= model.intercept_[0]
my_list[6][2]= int(traffic.max()['남원JC-북남원IC교통량'])



X = normalization[['남원JC-서남원IC교통량']]
y = traffic[['남원JC-서남원IC평균속도']]


model = LinearRegression()
model.fit(X, y)

print("y1.T10(남원JC-서남원IC)")
print("y=",round(model.coef_[0][0],2),"x +",round(model.intercept_[0],2))
print("교통량 최대값 = ",int(traffic.max()['남원JC-서남원IC교통량']),"\n")

my_list[4][0]= model.coef_[0][0]
my_list[4][1]= model.intercept_[0]
my_list[4][2]= int(traffic.max()['남원JC-서남원IC교통량'])



X = normalization[['북남원IC-남원JC교통량']]
y = traffic[['북남원IC-남원JC평균속도']]


model = LinearRegression()
model.fit(X, y)

print("x1.T1(북남원IC-남원JC)")
print("y=",round(model.coef_[0][0],2),"x +",round(model.intercept_[0],2))
print("교통량 최대값 = ",int(traffic.max()['북남원IC-남원JC교통량']),"\n")

my_list[0][0]= model.coef_[0][0]
my_list[0][1]= model.intercept_[0]
my_list[0][2]= int(traffic.max()['북남원IC-남원JC교통량'])


dataframe = pd.DataFrame(my_list)
dataframe.to_csv("남원_속도_비례식계수.csv",header=False, index=False)







