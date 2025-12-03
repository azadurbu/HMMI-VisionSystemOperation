# **VisionSystemOperation – HMMI Real-Time Vision Inspection System**

This repository contains the source code for **Hyundai Motors Manufacturing Indonesia (HMMI)** real-time vision inspection system.
The system performs **automated quality checks for car-type features and options** using industrial cameras and PLC-driven logic, ensuring fast and reliable OK/NG inspection on the production line.

Built using **C# WinForms**, **Cognex VisionPro**, **MSSQL**, and PLC signaling, the application captures and evaluates master images, makes real-time decisions, logs results, and integrates seamlessly with factory automation systems.

---

## ⭐ **Key Features**

* **Real-Time Vision Inspection**

  * Two active industrial cameras capture the full car.
  * High-speed image capture and Cognex VisionPro processing.
  * Manual capture option for operator-controlled inspection.

* **PLC Integration**

  * Trigger-based inspection workflow.
  * Sends OK/NG signals to control the production line.

* **Lighting Control**

  * Four independent light slots with adjustable intensity for optimal image quality.

* **Master Image & Model Management**

  * Master image references stored per car model.
  * Create custom models and options for new car types.

* **Operator-Friendly UI**

  * Multi-screen MDI interface with live camera feed and inspection overlay.
  * OK/NG indicators, parameter adjustment, and model selection.

* **Inspection History & Shift Management**

  * View past inspection results with timestamps.
  * Supports day and night shift tracking.

* **Data Logging & Storage**

  * Raw and processed images stored in the file system.
  * Inspection results recorded in MSSQL database.
  * System logs track camera events, PLC communication, and application activity.

---

## ⚙️ **Core System Features**

### **Vision-Based Car Feature Checks**

* **Car Type & Feature Verification** – Inspects presence, orientation, and alignment of components.
* **Master Image Comparison** – ROI-based inspection against master images for each car model.
* **Multi-Model & Option Support** – Configure ROIs, create custom models, and add new options for different car types.
* **Manual Image Capture** – Operators can capture images on demand in addition to automatic capture.

### **PLC & Automation Integration**

* **Trigger-Based Inspection** – Starts inspection automatically when PLC signals a car has reached the inspection zone.
* **OK/NG Output** – Sends results back to PLC for automated line control.

### **Lighting Control**

* **Four Independent Light Slots** – Each light intensity adjustable individually for optimal image quality.

### **WinForms Application Features**

* **Live Camera Feed** – Real-time monitoring with overlay of ROIs and detected features.
* **OK/NG Indicators** – Instant feedback on inspection results.
* **Model & Option Management** – Create or modify car models and options.
* **Parameter Adjustment** – Fine-tune inspection thresholds and detection logic.
* **Inspection History** – View and review past inspection results with timestamps.
* **Shift Management** – Supports day and night shifts with proper result tracking.

### **Data Storage & Logging**

* **Image Storage** – Save raw and processed images organized by model and timestamp.
* **Result Logging** – Store OK/NG status, feature results, model info, and timestamps in MSSQL.
* **System Logs** – Track camera events, PLC communication, and application activity.

---

## 📁 **Folder Structure Overview**

```
VisionSystemOperation
 ├── Class              # Core logic, helpers, business rules
 ├── Controls           # Custom WinForms controls
 ├── Device             # Camera, PLC, I/O modules
 ├── Forms              # Operator and engineering UI screens
 ├── Log                # Application logs
 ├── MasterImage        # Master images for each model
 ├── Properties         # Application settings and metadata
 ├── Resources          # Static UI assets (icons, etc.)
 ├── bin                # Compiled output
 ├── obj                # Build intermediates
 ├── App.config         # Configurations (SQL, settings)
 ├── FormMdi.*          # Main MDI interface
 ├── Program.cs         # Application entry point
 ├── VisionSystemOperation.csproj
 ├── packages.config    # NuGet package dependencies
bin                      # Solution-level build output
VisionSystemOperation.sln
script_20251022_dmt.sql  # SQL database structure
```

---

## 🔄 **How It Works (High-Level Workflow)**

### **Text-Based Flowchart**

```
        ┌────────────────────────────────────────────────┐
        │  PLC sends signal                              │
        │  (car reaches the designated inspection zone)  │
        └────────────────────────────────────────────────┘
                           │
                           ▼
        ┌────────────────────────────────────────────────┐
        │  Light & cameras activated                     │
        │  Two cameras capture full car image            │
        │  Save raw image to file-system                 │
        └────────────────────────────────────────────────┘
                           │
                           ▼
        ┌────────────────────────────────────────────────┐
        │  Cognex inspects captured images               │
        │  Generates processed images with ROIs          │
        │  Save processed images according to car model  │
        └────────────────────────────────────────────────┘
                           │
                           ▼
        ┌────────────────────────────────────────────────┐
        │  Vision logic determines OK / NG               │
        └────────────────────────────────────────────────┘
                           │
                           ▼
        ┌────────────────────────────────────────────────┐
        │  Result logged into MSSQL database             │
        └────────────────────────────────────────────────┘
                           │
                           ▼
        ┌────────────────────────────────────────────────┐
        │  Images stored with timestamped filenames      │
        │  (raw + processed images)                      │
        └────────────────────────────────────────────────┘
                           │
                           ▼
        ┌────────────────────────────────────────────────┐
        │  PLC receives final OK/NG signal               │
        └────────────────────────────────────────────────┘
                           │
                           ▼
        ┌────────────────────────────────────────────────┐
        │  Operator UI displays real-time inspection     │
        │  results, images, and system status            │
        └────────────────────────────────────────────────┘
```

---

## 🎥 **Process Demonstration Video**

A complete process demonstration video
[![Watch the video](https://github.com/azadurbu/HMMI-VisionSystemOperation/blob/main/thumbnail.png)](https://www.youtube.com/watch?v=1trFv8xxQcM)

This video shows real-time inspection flow:

* Car arrival informed via PLC
* Lighting activation and image capture using two cameras
* Raw + processed Cognex images
* OK/NG decision show by green or red color
* UI result updates

---

## 📄 **License**

This project is proprietary and developed for **Hyundai Motors Manufacturing Indonesia (HMMI)**.
Unauthorized distribution is prohibited.
