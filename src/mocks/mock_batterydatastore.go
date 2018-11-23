// Code generated by MockGen. DO NOT EDIT.
// Source: github.com/n7down/Forge/src/models (interfaces: BatteryDatastore)

// Package mocks is a generated GoMock package.
package mocks

import (
	gomock "github.com/golang/mock/gomock"
	models "github.com/n7down/Forge/src/models"
	reflect "reflect"
)

// MockBatteryDatastore is a mock of BatteryDatastore interface
type MockBatteryDatastore struct {
	ctrl     *gomock.Controller
	recorder *MockBatteryDatastoreMockRecorder
}

// MockBatteryDatastoreMockRecorder is the mock recorder for MockBatteryDatastore
type MockBatteryDatastoreMockRecorder struct {
	mock *MockBatteryDatastore
}

// NewMockBatteryDatastore creates a new mock instance
func NewMockBatteryDatastore(ctrl *gomock.Controller) *MockBatteryDatastore {
	mock := &MockBatteryDatastore{ctrl: ctrl}
	mock.recorder = &MockBatteryDatastoreMockRecorder{mock}
	return mock
}

// EXPECT returns an object that allows the caller to indicate expected use
func (m *MockBatteryDatastore) EXPECT() *MockBatteryDatastoreMockRecorder {
	return m.recorder
}

// AddBattery mocks base method
func (m *MockBatteryDatastore) AddBattery(arg0 models.BatteryRequest) error {
	ret := m.ctrl.Call(m, "AddBattery", arg0)
	ret0, _ := ret[0].(error)
	return ret0
}

// AddBattery indicates an expected call of AddBattery
func (mr *MockBatteryDatastoreMockRecorder) AddBattery(arg0 interface{}) *gomock.Call {
	return mr.mock.ctrl.RecordCallWithMethodType(mr.mock, "AddBattery", reflect.TypeOf((*MockBatteryDatastore)(nil).AddBattery), arg0)
}

// GetAllBatteries mocks base method
func (m *MockBatteryDatastore) GetAllBatteries() ([]*models.BatteryResponse, error) {
	ret := m.ctrl.Call(m, "GetAllBatteries")
	ret0, _ := ret[0].([]*models.BatteryResponse)
	ret1, _ := ret[1].(error)
	return ret0, ret1
}

// GetAllBatteries indicates an expected call of GetAllBatteries
func (mr *MockBatteryDatastoreMockRecorder) GetAllBatteries() *gomock.Call {
	return mr.mock.ctrl.RecordCallWithMethodType(mr.mock, "GetAllBatteries", reflect.TypeOf((*MockBatteryDatastore)(nil).GetAllBatteries))
}
