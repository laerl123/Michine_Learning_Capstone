import pandas as pd
import numpy as np
from sklearn.linear_model import LinearRegression
from sklearn.preprocessing import MinMaxScaler
import matplotlib.pyplot as plt

T1 = pd.read_csv("수원신갈_기흥_2020년_7월부터_12월_교통량속도.csv")

X = T1[['교통량']]
y = T1[['평균속도']]

T1model = LinearRegression()
T1model.fit(X, y)

T1coef = float(T1model.coef_[0][0]) #기울기
T1intercept = float(T1model.intercept_[0]) #상수
T1traffic = 4000 #임의로 넣은 교통량
T1velocity = round(T1coef * T1traffic + T1intercept,2) #속도
T1congest = int(T1traffic / float(T1.max()[0]) * 100) #혼잡도

print("T1 : 속도=",T1velocity,"km 혼잡도=",T1congest,"% 최대교통량=",int(T1.max()[0]))



T3 = pd.read_csv("기흥_기흥동탄_2020년_7월부터_12월_교통량속도.csv")

X = T3[['교통량']]
y = T3[['평균속도']]

T3model = LinearRegression()
T3model.fit(X, y)

T3coef = float(T3model.coef_[0][0]) #기울기
T3intercept = float(T3model.intercept_[0]) #상수
T3traffic = 4000 #임의로 넣은 교통량
T3velocity = round(T3coef * T3traffic + T3intercept,2) #속도
T3congest = int(T3traffic / float(T3.max()[0]) * 100) #혼잡도

print("T3 : 속도=",T3velocity,"km 혼잡도=",T3congest,"% 최대교통량=",int(T3.max()[0]))




T5 = pd.read_csv("Re기흥동탄_동탄_2020년_7월부터_12월_교통량속도.csv")

X = T5[['교통량']]
y = T5[['평균속도']]

T5model = LinearRegression()
T5model.fit(X, y)

T5coef = float(T5model.coef_[0][0]) #기울기
T5intercept = float(T5model.intercept_[0]) #상수
T5traffic = 4000 #임의로 넣은 교통량
T5velocity = round(T5coef * T5traffic + T5intercept,2) #속도
T5congest = int(T5traffic / float(T3.max()[0]) * 100) #혼잡도

print("T5 : 속도=",T5velocity,"km 혼잡도=",T5congest,"% 최대교통량=",int(T5.max()[0]))
