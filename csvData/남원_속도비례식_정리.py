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


#plt.scatter(X, y)
#plt.show()

print("남원 속도 비례식 정리. x는 0~1사이의 혼잡도\n\n")

print("T12_2(순창IC-남원JC)")
print("y=",round(model.coef_[0][0],2),"x +",round(model.intercept_[0],2))
print("교통량 최대값 = ",int(traffic.max()['순창IC-남원JC교통량']),"\n")



X = normalization[['남원JC-남원IC교통량']]
y = traffic[['남원JC-남원IC평균속도']]


model = LinearRegression()
model.fit(X, y)


#plt.scatter(X, y)
#plt.show()

print("T11_2(남원JC-남원IC)")
print("y=",round(model.coef_[0][0],2),"x +",round(model.intercept_[0],2))
print("교통량 최대값 = ",int(traffic.max()['남원JC-남원IC교통량']),"\n")




X = normalization[['남원JC-순창IC교통량']]
y = traffic[['남원JC-순창IC평균속도']]


model = LinearRegression()
model.fit(X, y)


#plt.scatter(X, y)
#plt.show()

print("T12(남원JC-순창IC)")
print("y=",round(model.coef_[0][0],2),"x +",round(model.intercept_[0],2))
print("교통량 최대값 = ",int(traffic.max()['남원JC-순창IC교통량']),"\n")




X = normalization[['남원IC-남원JC교통량']]
y = traffic[['남원IC-남원JC평균속도']]


model = LinearRegression()
model.fit(X, y)


#plt.scatter(X, y)
#plt.show()

print("T11(남원IC-남원JC)")
print("y=",round(model.coef_[0][0],2),"x +",round(model.intercept_[0],2))
print("교통량 최대값 = ",int(traffic.max()['남원IC-남원JC교통량']),"\n")




X = normalization[['서남원IC-남원JC교통량']]
y = traffic[['서남원IC-남원JC평균속도']]


model = LinearRegression()
model.fit(X, y)


#plt.scatter(X, y)
#plt.show()

print("T10_2(서남원IC-남원JC)")
print("y=",round(model.coef_[0][0],2),"x +",round(model.intercept_[0],2))
print("교통량 최대값 = ",int(traffic.max()['서남원IC-남원JC교통량']),"\n")




X = normalization[['남원JC-북남원IC교통량']]
y = traffic[['남원JC-북남원IC평균속도']]


model = LinearRegression()
model.fit(X, y)


#plt.scatter(X, y)
#plt.show()

print("T1_2(남원JC-북남원IC)")
print("y=",round(model.coef_[0][0],2),"x +",round(model.intercept_[0],2))
print("교통량 최대값 = ",int(traffic.max()['남원JC-북남원IC교통량']),"\n")




X = normalization[['남원JC-서남원IC교통량']]
y = traffic[['남원JC-서남원IC평균속도']]


model = LinearRegression()
model.fit(X, y)


#plt.scatter(X, y)
#plt.show()

print("T10(남원JC-서남원IC)")
print("y=",round(model.coef_[0][0],2),"x +",round(model.intercept_[0],2))
print("교통량 최대값 = ",int(traffic.max()['남원JC-서남원IC교통량']),"\n")



X = normalization[['북남원IC-남원JC교통량']]
y = traffic[['북남원IC-남원JC평균속도']]


model = LinearRegression()
model.fit(X, y)


#plt.scatter(X, y)
#plt.show()

print("T1(북남원IC-남원JC)")
print("y=",round(model.coef_[0][0],2),"x +",round(model.intercept_[0],2))
print("교통량 최대값 = ",int(traffic.max()['북남원IC-남원JC교통량']),"\n")
